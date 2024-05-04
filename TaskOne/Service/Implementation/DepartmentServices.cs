using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskOne.Infrastructure.Repository.IRepo;
using TaskOne.Infrastructure.Repository.Repo;
using TaskOne.Models;
using TaskOne.Pagination;
using TaskOne.Service.Abstract;
using TaskOne.ViewModel;

namespace TaskOne.Service.Implementation
{
    public class DepartmentServices : IDepartmentServices
    {
        #region Fields
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor
        public DepartmentServices(IDepartmentRepo departmentRepo , IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        #region CRUD
        public async Task<string> AddDepartment(Department department)
        {
            await _departmentRepo.AddAsync(department);
            return "Success";
        }
        public async Task<List<int>> GetDepartmentsIDs()
        {
            return _departmentRepo.GetTableNoTracking().Select(x => x.Id).ToList();
        }
        public async Task<string> UpdateDepartment(Department department)
        {
            await _departmentRepo.UpdateAsync(department);
            return "Success";
        }
        public async Task<Department> GetDepartmentByID(int id)
        {
            return await _departmentRepo.GetByIdAsync(id);
        }

        public async Task<string> DeleteDepartment(int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);
            await _departmentRepo.DeleteAsync(department);
            return "Success";
        }

        public async Task<PaginatedResult<DepartmentVM>> GetAllDepartment(int PageNumber, int PageSize, string? Search)
        {
            var depst = await _departmentRepo.GetTableNoTracking().ToListAsync();
            if (Search != null)
            {
                depst = depst.Where(x => x.Name.Contains(Search)).ToList();
            }
           // var depQr = depst.AsQueryable();
            return await _mapper.ProjectTo<DepartmentVM>(depst.AsQueryable()).ToPaginatedListAsync(PageNumber,PageSize);
          
        }
        #endregion
        #endregion
    }
}
