using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RedSpark.Thot.Api.Application.Interfaces;
using RedSpark.Thot.Api.Application.Models.Generics.Output;
using RedSpark.Thot.Api.Application.Models.Users.Input;
using RedSpark.Thot.Api.Application.Models.Users.Output;
using RedSpark.Thot.Api.Domain.Core.Notifications;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;
using RedSpark.Thot.Api.Domain.Interfaces.UnitOfWork;
using RedSpark.Thot.Api.Infra.CrossCutting.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Application.Sevices
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private Domain.Interfaces.Validators.IUserValidator _userValidator;

        private INotificationHandler _notificationHandler;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppSettings _appSettings;
        public AuthService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            Domain.Interfaces.Validators.IUserValidator userValidator,
            INotificationHandler notificationHandler, 
            SignInManager<User> signInManager, 
            UserManager<User> userManager,
            IOptions<MySettings> settings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userValidator = userValidator;
            _notificationHandler = notificationHandler;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = settings.Value.AppSettings;
        }

        public async Task<UserCreatedModel> Register(UserCreateModel newUser)
        {
            var userCreated = new UserCreatedModel();

            var user = new User()
            {
                UserName = newUser.Email,
                Email = newUser.Email,
                EmailConfirmed = true
            };

            var valid = _userValidator.Creation(user);
            if (valid)
            {
                var resul = await _userManager.CreateAsync(user, newUser.Password);
                if (resul.Succeeded)
                {
                    // Atualizando Person relacionada ao user
                    var person = _unitOfWork.GetRepository<IPersonRepository>().GetByEmail(user.Email);
                    user.SetPerson(person);

                    await _signInManager.SignInAsync(user, false);
                    if (!_unitOfWork.Commit())
                    {
                        _notificationHandler.Handler(new Notification("signup.fail"));
                    }

                    userCreated.Token = GenerateJwt();
                    return userCreated;
                }
            }
            
            userCreated.Erros = _mapper.Map<List<ErroModel>>(_notificationHandler.GetNotifications());

            return userCreated;
        }

        private string GenerateJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _appSettings.From,
                Audience = _appSettings.ValidIn,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHour),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

    }
}
