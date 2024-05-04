using AutoMapper;
using TaskOne.Models;
using TaskOne.ViewModel;

namespace TaskOne.Mapping.EmployeeMapping
{
    public partial class EmployeeProfile : Profile
    {
        public void EmployeeVMMapping()
        {

            CreateMap<employee, EmployeeVM>()
           .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(src => src.ProfileImage))
           .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedByUser != null ? src.CreatedByUser.Name : ""))
           .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedByUser != null ? src.ModifiedByUser.Name : ""))
           .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name));


            CreateMap<employee, AddEmployeVM>().ReverseMap();

            CreateMap<employee, EmployeeEditVM>()
            .ForMember(dest => dest.ProfileImage, opt => opt.Ignore()) // Ignore mapping for ProfileImage
            .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(src=>src.ProfileImage)) // Ignore mapping for ProfileImage
            .ReverseMap();
        }

    }
}
