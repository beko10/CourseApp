using AutoMapper;
using CourseApp.EntityLayer.Dto.RegistrationDto;
using CourseApp.EntityLayer.Entity;

namespace CourseApp.ServiceLayer.Mapping;

public class RegistrationMapping:Profile
{
    public RegistrationMapping()
    {
        CreateMap<Registration,GetAllRegistrationDto>().ReverseMap();
        CreateMap<Registration,GetByIdRegistrationDto>().ReverseMap();
        CreateMap<Registration,CreateRegistrationDto>().ReverseMap();
        CreateMap<Registration,UpdatedRegistrationDto>().ReverseMap();
        CreateMap<Registration,DeleteRegistrationDto>().ReverseMap();
    }
}
