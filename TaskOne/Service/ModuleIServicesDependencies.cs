using TaskOne.Service.Abstract;
using TaskOne.Service.Implementation;

namespace TaskOne.Service
{
    public static class ModuleIServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IDepartmentServices, DepartmentServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IMediaService, MediaService>();

            return services;
        }
    }
}
