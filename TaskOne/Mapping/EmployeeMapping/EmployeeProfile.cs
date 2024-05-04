using AutoMapper;

namespace TaskOne.Mapping.EmployeeMapping
{
    public partial class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            EmployeeVMMapping();
        }
    }
}
