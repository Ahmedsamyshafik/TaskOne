using AutoMapper;

namespace TaskOne.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            DepartmentVMMapping(); 
        }
    }
}
