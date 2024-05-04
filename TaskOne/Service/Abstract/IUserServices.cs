using TaskOne.Models;
using TaskOne.Pagination;
using TaskOne.ViewModel;

namespace TaskOne.Service.Abstract
{
    public interface IUserServices
    {
        Task<string> AddUser(User user);
        Task<string> UpdateUser(User user);
        Task<User> GetUserByID(int id);
        Task<PaginatedResult<UserVM>> GetAllUsers(int PageNumber, int PageSize, string? Search);
        Task<string> DeleteUser(int id);
        Task<List<int>> GetUsersIDs();
    }
}
