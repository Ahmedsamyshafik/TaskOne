using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models;
using TaskOne.Service.Abstract;
using TaskOne.Service.Implementation;
using TaskOne.ViewModel;

namespace TaskOne.Controllers
{
    public class DepartmentController : Controller
    {
        #region inJect
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentServices departmentServices, IMapper mapper)//, IMapper mapper
        {
            _departmentServices = departmentServices;
            _mapper = mapper;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index(int pageSize, int pageNumber, string? search)
        {
            //Service - mapping
            var departments = await _departmentServices.GetAllDepartment(pageNumber, pageSize, search);
            //return
            return View(departments);
        }
        [HttpGet]
        public async Task<IActionResult> AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentVM department)
        {
            if (ModelState.IsValid)
            {
                //mapper
                var DepartmentMapper = _mapper.Map<Department>(department);
                //service
                var result = await _departmentServices.AddDepartment(DepartmentMapper);
                //return
                if (result == "Success") { return View(); }
            }
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentByID(int id)
        {
            //Service
            var dep = await _departmentServices.GetDepartmentByID(id);
            if (dep == null) return NotFound();
            //mapper
            var result = _mapper.Map<DepartmentVM>(dep);
            //return
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(int id)
        {
            //Service
            var dep = await _departmentServices.GetDepartmentByID(id);
            if (dep == null) return NotFound();
            //mapper
            var result = _mapper.Map<DepartmentVM>(dep);
            //return
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(DepartmentVM department)
        {
            if (ModelState.IsValid)
            {
                var Dept = _mapper.Map<Department>(department);
                //service
                var result = await _departmentServices.UpdateDepartment(Dept);
                //return
                if (result == "Success") return View(department);
            }
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            //Service
            var dep = await _departmentServices.GetDepartmentByID(id);
            if (dep == null) return NotFound();
            //mapper
            var result = _mapper.Map<DepartmentVM>(dep);
            //return
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var result = await _departmentServices.DeleteDepartment(id);
            if (result == "Success")return RedirectToAction("Index","Home");
            return RedirectToAction("DeleteApartment",id);
        }

    }


}
