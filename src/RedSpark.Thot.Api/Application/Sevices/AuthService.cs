using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RedSpark.Thot.Api.Application.Interfaces;
using RedSpark.Thot.Api.Application.Models.Generics.Output;
using RedSpark.Thot.Api.Application.Models.Users.Input;
using RedSpark.Thot.Api.Application.Models.Users.Output;
using RedSpark.Thot.Api.Domain.Core.Notifications;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;
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

        public AuthService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            Domain.Interfaces.Validators.IUserValidator userValidator,
            INotificationHandler notificationHandler, 
            SignInManager<User> signInManager, 
            UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userValidator = userValidator;
            _notificationHandler = notificationHandler;
            _signInManager = signInManager;
            _userManager = userManager;
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
                    await _signInManager.SignInAsync(user, false);
                    return userCreated;
                }
            }
            
            userCreated.Erros = _mapper.Map<List<ErroModel>>(_notificationHandler.GetNotifications());

            return userCreated;
        }



    }
}
