using Microsoft.EntityFrameworkCore;
using TaskOne.Infrastructure.GenericRepository;
using TaskOne.Infrastructure.Repository.IRepo;
using TaskOne.Models.Data;
using TaskOne.Models;

namespace TaskOne.Infrastructure.Repository.Repo
{
    public class EmployeeRepo : GenericRepository<employee>, IEmployeeRepo
    {
        private readonly DbSet<employee> employees;
        public EmployeeRepo(AppDbContext db) : base(db)
        {
            employees = db.Set<employee>();
        }
    }
}