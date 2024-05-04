using AutoMapper;

namespace TaskOne.Mapping.UserMapping
{
    public partial class UserProfile :Profile
    {
        public UserProfile()
        {
            UserVMMapper();
        }
    }
}
