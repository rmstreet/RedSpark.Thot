using AutoMapper;
using RedSpark.Thot.Api.Application.Interfaces;
using RedSpark.Thot.Api.Application.Models.Generics.Output;
using RedSpark.Thot.Api.Application.Models.Leads.Input;
using RedSpark.Thot.Api.Application.Models.Leads.Output;
using RedSpark.Thot.Api.Domain.Core.Notifications;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;
using RedSpark.Thot.Api.Domain.Interfaces.UnitOfWork;
using RedSpark.Thot.Api.Domain.Interfaces.Validators;
using System.Collections.Generic;
using System.Linq;

namespace RedSpark.Thot.Api.Application.Sevices
{
    public class LeadService : ILeadService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILeadValidator _leadValidator;
        private INotificationHandler _notificationHandler;

        public LeadService(IUnitOfWork unitOfWork, IMapper mapper, ILeadValidator leadValidator, INotificationHandler notificationHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _leadValidator = leadValidator;
            _notificationHandler = notificationHandler;
        }


        public LeadDetailsModel Creation(LeadCreateModel leadModel)
        {
            // TODO: Resolve Usuario atual(Logado)
            var userId = 1;

            leadModel.CreatedById = userId;
            
            var lead = _mapper.Map<Lead>(leadModel);

            // TODO: Validator 
            _leadValidator.Creation(lead);

            // TODO: Chama repository
            var leadRepository =  _unitOfWork.GetRepository<ILeadRepository>();
            var leadCreated = leadRepository.Create(lead);
                       

            LeadDetailsModel leadDetailsModel = new LeadDetailsModel();

            // TODO: Commit
            if (!_unitOfWork.Commit())
            {
                leadDetailsModel.Erros = _mapper.Map<List<ErroModel>>(_notificationHandler.GetNotifications());
                return leadDetailsModel;
            }

            // TODO: Devolver objeto sucesso ou falha
            leadDetailsModel = _mapper.Map<LeadDetailsModel>(lead);

            return leadDetailsModel;
        }

    }
}
