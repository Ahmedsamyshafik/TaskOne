using TaskOne.Models;
using TaskOne.Pagination;
using TaskOne.ViewModel;

namespace TaskOne.Service.Abstract
{
    public interface IDepartmentServices
    {
        Task<string> AddDepartment(Department department);
        Task<string> UpdateDepartment(Department department);
        Task<Department> GetDepartmentByID(int id);
        Task<PaginatedResult<DepartmentVM>> GetAllDepartment(int PageNumber, int PageSize, string? Search);
        Task<string> DeleteDepartment(int id);
        Task<List<int>> GetDepartmentsIDs();
    }
}
