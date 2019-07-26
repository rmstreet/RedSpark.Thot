using AutoMapper;

namespace RedSpark.Thot.Api.Application.AutoMapper
{
    public class AutoMapperSetup
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToModelMappingProfile());
                cfg.AddProfile(new ModelToDomainMappingProfile());
            });
        }
    }
}
