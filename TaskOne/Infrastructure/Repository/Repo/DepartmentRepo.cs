using Microsoft.EntityFrameworkCore;
using TaskOne.Models.Data;
using TaskOne.Models;
using TaskOne.Infrastructure.GenericRepository;
using TaskOne.Infrastructure.Repository.IRepo;

namespace TaskOne.Infrastructure.Repository.Repo
{
    public class DepartmentRepo : GenericRepository<Department>, IDepartmentRepo
    {
        private readonly DbSet<Department> departments;
        public DepartmentRepo(AppDbContext db) : base(db)
        {
            departments = db.Set<Department>();
        }
    }
}
