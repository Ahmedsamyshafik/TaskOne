using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskOne.Models;
using TaskOne.Service.Abstract;
using TaskOne.ViewModel;

namespace TaskOne.Controllers
{
    public class EmployeeController : Controller
    {
        #region Inject 
        private readonly IEmployeeServices _employeeServices;
        private readonly IDepartmentServices _departmentServices;
        private readonly IUserServices _userServices;

        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeServices employeeServices, IMapper mapper, IDepartmentServices departmentServices
           , IUserServices userServices )
        {
            _employeeServices = employeeServices;
            _mapper = mapper;
            _departmentServices = departmentServices;
            _userServices = userServices;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber,int PageSize,string? Search)
        {
            //Service-mapper
            var employees = await _employeeServices.GetAllEmployee(pageNumber,PageSize,Search);
            //return
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var UsersID = await _userServices.GetAllUsers(0,0,null);
            

            var x= await _userServices.GetAllUsers(0, 0, null);
            ViewBag.CreatedBy = x.Date.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            var Departments = await _departmentServices.GetAllDepartment(0,0,null);
            ViewBag.DepartmentID = Departments.Date.Select(d => new SelectListItem
                                    {
                                        Value = d.Id.ToString(),
                                        Text = d.Name
                                    }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeVM employee)
        {
            if (ModelState.IsValid)
            {
                //Mapper
                var emp = _mapper.Map<employee>(employee);
                //Service
                emp.HireDate = DateTime.Now;
                emp.CreatedDate = DateTime.Now;
                emp.ModifiedBy=emp.CreatedBy;
                var result = await _employeeServices.AddEmployee(emp, employee.ProfileImage);

                if (result == "Success")
                {
                    var x = await _userServices.GetAllUsers(0, 0, null);
                    ViewBag.CreatedBy = x.Date.Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    }).ToList();
                    var Departments = await _departmentServices.GetAllDepartment(0, 0, null);
                    ViewBag.DepartmentID = Departments.Date.Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    }).ToList();
                    return View();
                }
            }
            return View(employee);
        }
        #region MyRegion

        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            //Service
            var emp = await _employeeServices.GetEmployeeByID(id);
            if (emp == null) return NotFound();
            //Mapper
            var mapperEmployee = _mapper.Map<EmployeeVM>(emp);
            //Return
            return View(mapperEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            //Service
            var emp = await _employeeServices.GetEmployeeByID(id);
            if (emp == null) return NotFound();
            //Mapper
            var mapperEmployee = _mapper.Map<EmployeeEditVM>(emp);
            //Return
            //View Bags
            var UsersID = await _userServices.GetUsersIDs();
            ViewBag.CreatedBy = UsersID.Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString() }).ToList();
            ViewBag.ModifiedBy = UsersID.Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString() }).ToList();

            var DepartmentsIDs = await _departmentServices.GetDepartmentsIDs();
            ViewBag.DepartmentID = DepartmentsIDs.Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString() }).ToList();

            return View(mapperEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeEditVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                //mapper
                var emp = _mapper.Map<employee>(employeeVM);
                if (emp == null) return NotFound();
                //service
                var result = await _employeeServices.UpdateEmployee(emp, employeeVM.ProfileImage);
                //return
                if (result == "Success") return View(employeeVM);
            }
            return View(employeeVM);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            //Service
            var emp = await _employeeServices.GetEmployeeByID(id);
            if (emp == null) return NotFound();
            //Mapper
            var mapperEmployee = _mapper.Map<EmployeeVM>(emp);
            //Return
            return View(mapperEmployee);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var result = await _employeeServices.DeleteEmployee(id);
            if (result == "Success") return RedirectToAction("Index");
            return RedirectToAction("DeleteEmployee",id);
        }
        #endregion



    }
}
