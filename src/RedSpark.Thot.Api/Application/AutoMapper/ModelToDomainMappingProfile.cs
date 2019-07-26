using AutoMapper;
using RedSpark.Thot.Api.Application.Models.Leads.Input;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Infra.CrossCutting.Extensions;

namespace RedSpark.Thot.Api.Application.AutoMapper
{
    internal class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            CreateMap<LeadCreateModel, Lead>()
                .ConvertUsing(model =>
                new Lead(model.Title, model.CreatedById, model.Status.Parse<LeadStatus>())); ;

            // TODO: Sem utilizar a Extension como ficaria
            //(LeadStatus)Enum.Parse(typeof(LeadStatus), model.Status);
        }
    }
}
