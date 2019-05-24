using AutoMapper;
using Red.Application.AutoMapper;
using Red.DomainValidation;

namespace Red.Application
{
    public class BaseServiceApp
    {
        protected readonly IMapper Mapper;
        protected ValidationResult ValidationResult;

        public BaseServiceApp()
        {
            AutoMapperConfig.RegisterMappings();
            Mapper = AutoMapperConfig.Config.CreateMapper();
            ValidationResult = new ValidationResult();
        }

    }
}