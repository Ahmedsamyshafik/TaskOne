using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskOne.Infrastructure.Repository.IRepo;
using TaskOne.Models;
using TaskOne.Pagination;
using TaskOne.Service.Abstract;
using TaskOne.ViewModel;

namespace TaskOne.Service.Implementation
{
    public class UserServices : IUserServices
    {
        #region Fields
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public UserServices(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        #endregion

        #region Handle Functions
        #region CRUD
        public async Task<string> AddUser(User user)
        {
            await _userRepo.AddAsync(user);
            return "Success";
        }

        public async Task<List<int>> GetUsersIDs()
        {
            var x= _userRepo.GetTableNoTracking().ToList();
            return x.Select(x=>x.Id).ToList();  
        }
        public async Task<string> UpdateUser(User user)
        {
            await _userRepo.UpdateAsync(user);
            return "Success";
        }
        public async Task<User> GetUserByID(int id)
        {
            return await _userRepo.GetByIdAsync(id);
        }
        public async Task<PaginatedResult<UserVM>> GetAllUsers(int PageNumber, int PageSize, string? Search)
        {
            var users = await _userRepo.GetTableNoTracking().ToListAsync();
            if (Search != null)
            {
                users = users.Where(x => x.Name.Contains(Search)).ToList();
            }
            //   return await _mapper.ProjectTo<DepartmentVM>(depst.AsQueryable()).ToPaginatedListAsync(PageNumber,PageSize);
            var usersQr = users.AsQueryable();
            return await _mapper.ProjectTo<UserVM>(usersQr).ToPaginatedListAsync(PageNumber, PageSize);
         

        }
        public async Task<string> DeleteUser(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            await _userRepo.DeleteAsync(user);
            return "Success";
        }
        #endregion


        #endregion
    }
}
