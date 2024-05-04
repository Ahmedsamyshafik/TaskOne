using Microsoft.EntityFrameworkCore;
using TaskOne.Infrastructure.GenericRepository;
using TaskOne.Infrastructure.Repository.IRepo;
using TaskOne.Models.Data;
using TaskOne.Models;

namespace TaskOne.Infrastructure.Repository.Repo
{
    public class UserRepo : GenericRepository<User>, IUserRepo
    {
        private readonly DbSet<User> users;
        public UserRepo(AppDbContext db) : base(db)
        {
            users = db.Set<User>();
        }
    }
}
