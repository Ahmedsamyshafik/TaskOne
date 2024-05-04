using TaskOne.Infrastructure.Repository.IRepo;
using TaskOne.Infrastructure.Repository.Repo;

namespace TaskOne.Infrastructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepo,EmployeeRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient<IUserRepo, UserRepo>();


            return services;
        }
    }
}
