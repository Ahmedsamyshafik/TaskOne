using TaskOne.Models;
using TaskOne.Pagination;
using TaskOne.ViewModel;

namespace TaskOne.Service.Abstract
{
    public interface IEmployeeServices
    {
        Task<string> AddEmployee(employee employee ,IFormFile? file);
        Task<string> UpdateEmployee(employee employee, IFormFile? file);
        Task<employee> GetEmployeeByID(int id);
        Task<PaginatedResult<EmployeeVM>> GetAllEmployee(int PageNumber, int PageSize, string? Search);
        Task<string> DeleteEmployee(int id);
    }
}
