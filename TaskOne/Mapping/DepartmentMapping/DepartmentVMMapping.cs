using AutoMapper;
using TaskOne.Models;
using TaskOne.ViewModel;

namespace TaskOne.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile :Profile
    {
        public void DepartmentVMMapping()
        {
            CreateMap<Department,DepartmentVM>()
                .ReverseMap();
        }
    }
}
