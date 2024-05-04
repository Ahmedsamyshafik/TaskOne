using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using TaskOne.Service.Abstract;

namespace TaskOne.Models.Seeder
{
    public static class Seeder
    {
        
        public static async Task Seed(IServiceProvider serviceProvider, IUserServices userServices, IDepartmentServices departmentServices)
        {
            // Now you can use userServices and departmentServices within this method
            var user = new User()
            {
                Email = "user@gmail.com",
                Name = "Ahmed Samy",
                Password = "Password"
            };

            // Example usage of userServices
            try
            {
                await userServices.AddUser(user);

            }
            catch
            {
            }

            var department = new Department()
            {
                Description = "Des",
                Name = "CS"
            };
            await departmentServices.AddDepartment(department);
            var uss = userServices.GetAllUsers(1, 10, null);
            var uds = departmentServices.GetAllDepartment(1, 10, null);
        }
    }
}
