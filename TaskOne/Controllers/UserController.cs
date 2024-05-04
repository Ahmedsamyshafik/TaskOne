using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models;
using TaskOne.Service.Abstract;
using TaskOne.ViewModel;

namespace TaskOne.Controllers
{
    public class UserController : Controller
    {
        #region Inject
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        #endregion

        public async Task<IActionResult> Index(int pageSize, int pageNumber, string? search)
        {
            //Service - mapping
            var users = await _userServices.GetAllUsers(pageNumber, pageSize, search);

            //return
            return View(users);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserVM user)
        {
            if (ModelState.IsValid)
            {
                //mapping
                var UserMapper = _mapper.Map<User>(user);
                //service
                var result = await _userServices.AddUser(UserMapper);
                //return
                if (result == "Success") return View();
                return View(result);

            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserData(int id)
        {
            var user = await _userServices.GetUserByID(id);
            var mapperUser=_mapper.Map<UserVM>(user);
            return View(mapperUser);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var user = await _userServices.GetUserByID(id);
            if (user == null) return BadRequest();
            var mapperUser = _mapper.Map<UserVM>(user);

            return View(mapperUser);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserVM user)
        {
            if (ModelState.IsValid)
            {
                var mapperUser = _mapper.Map<User>(user);
                var result = await _userServices.UpdateUser(mapperUser);
                if (result == "Success") return View(user);
                return BadRequest(result);
            }
            return BadRequest(user);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userServices.GetUserByID(id);
            return View(user);
        }
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var result = await _userServices.DeleteUser(id);
            if (result == "Success")return RedirectToAction("Index","Home");
            return RedirectToAction("DeleteUser",id);
        }

    }
}
