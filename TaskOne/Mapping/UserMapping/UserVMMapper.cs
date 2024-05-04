using AutoMapper;
using TaskOne.Models;
using TaskOne.ViewModel;

namespace TaskOne.Mapping.UserMapping
{
    public partial class UserProfile:Profile
    {
        public void UserVMMapper()
        {
            CreateMap<User, UserVM>().ReverseMap();
        }
    }
}
