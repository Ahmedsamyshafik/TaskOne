using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TaskOne.Infrastructure.Repository.IRepo;
using TaskOne.Infrastructure.Repository.Repo;
using TaskOne.Models;
using TaskOne.Pagination;
using TaskOne.Service.Abstract;
using TaskOne.ViewModel;

namespace TaskOne.Service.Implementation
{
    public class EmployeeServices : IEmployeeServices
    {
        #region Fields
        private readonly IMediaService _mediaService;
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUserServices _userService;
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public EmployeeServices(IEmployeeRepo employee, IMediaService mediaService, IMapper mapper,
            IUserServices userService, IDepartmentServices departmentServices)
        {
            _employeeRepo = employee;
            _mediaService = mediaService;
            _mapper = mapper;
            _userService = userService;
            _departmentServices = departmentServices;
        }
        #endregion

        #region Handle Functions
        public async Task<string> AddEmployee(employee employee, IFormFile? file)
        {
            if (file!=null && file.Length>0)
            {
                var result = await _mediaService.Upload(file);
                employee.ProfileImage = result;
            }
            await _employeeRepo.AddAsync(employee);
            return "Success";
        }
        public async Task<string> UpdateEmployee(employee employee, IFormFile? file)
        {
            if (file!=null&&file.Length > 0)
            {
                var result = await _mediaService.Upload(file);
                employee.ProfileImage = result;

            }
            await _employeeRepo.UpdateAsync(employee);
            return "Success";
        }
        public async Task<employee> GetEmployeeByID(int id)
        {
            return await _employeeRepo.GetTableNoTracking().Include(x=>x.CreatedByUser).Include(x=>x.Department).Include(x=>x.ModifiedByUser).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }
        public async Task<PaginatedResult<EmployeeVM>> GetAllEmployee(int PageNumber, int PageSize, string? Search)
        {
            var employees = await _employeeRepo.GetTableNoTracking().Include(x=>x.Department)
                .Include(x=>x.ModifiedByUser).Include(x=>x.CreatedByUser)
                .ToListAsync();
            if (Search != null)
            {
                employees = employees.Where(x => x.Name.Contains(Search)).ToList();
            }
 
            var result = await _mapper.ProjectTo<EmployeeVM>(employees.AsQueryable()).ToPaginatedListAsync(PageNumber, PageSize);


            return result;
        }

        public async Task<string> DeleteEmployee(int id)
        {
            var user = await _employeeRepo.GetByIdAsync(id);
            await _employeeRepo.DeleteAsync(user);
            return "Success";
        }


      
        #endregion
    }
}
