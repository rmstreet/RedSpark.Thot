using AutoMapper;
using RedSpark.Thot.Api.Domain.Core.Notifications;

namespace RedSpark.Thot.Api.Application.AutoMapper
{
    internal class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<Notification, Application.Models.Generics.Output.ErroModel>();
        }
    }
}
