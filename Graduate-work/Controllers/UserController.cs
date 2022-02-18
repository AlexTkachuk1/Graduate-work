using AutoMapper;
using Graduate_work.Controllers.AuthAttribute;
using Graduate_work.EfStuff.Repositories;
using Graduate_work.Model;
using Graduate_work.Models;
using Graduate_work.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Graduate_work.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        private IMapper _mapper;
        private UserService _userServis;

        public UserController(UserRepository userRepository, IMapper mapper, UserService userServis)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userServis = userServis;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", registrationViewModel);
            }
            var user = _mapper.Map<User>(registrationViewModel);

            _userRepository.Save(user);

            return View("Index");

        }

        [HttpGet]
        public IActionResult Login()
        {
            var returnUrl = Request.Query["ReturnUrl"].FirstOrDefault();
            var viewModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = _userRepository.Get(loginViewModel.Login, loginViewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Login), "Неправильный логин или пароль");
                return View(loginViewModel);
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Login.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
            claims.Add(new Claim(
                ClaimTypes.AuthenticationMethod,
                Startup.AuthName));
            var claimsIdentity = new ClaimsIdentity(claims, Startup.AuthName);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
            if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
            {
                return Redirect("Index");
            }

            return Redirect(loginViewModel.ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Denied()
        {
            ViewBag.UserName = _userServis.GetCurrent().Login;
            return View(ViewBag);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            var user = _userServis.GetCurrent();
            var profileViewModel = _mapper.Map<ProfileViewModel>(user);
            return View(profileViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddProfileData(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", profileViewModel);
            }
            var user = _userServis.GetCurrent();

            user = _mapper.Map<User>(profileViewModel);

            _userRepository.Save(user);

            return View("Index");
        }

        [HttpGet]
        [Authorize]
        [OnliAdmin]
        public IActionResult ChangeRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [OnliAdmin]
        public IActionResult ChangeRole(ChangeRoleViewModel changeRoleViewModel)
        {
            var rolValue = (int)Enum.Parse(typeof(Role), changeRoleViewModel.Role);
            var user = _userRepository.Get(changeRoleViewModel.Id);
            user.Role = (Role)rolValue;
            _userRepository.Save(user);
            return View("Index");
        }

        public IActionResult IsUniq(string name)
        {
            var isUniq =!_userRepository.Exist(name);
            return Json(isUniq);
        }

        [HttpGet]
        [Authorize]
        [OnliAdmin]
        public IActionResult GetFavoriteBooks(ChangeRoleViewModel changeRoleViewModel)
        {
            var currentUserFavoriteBooks = _userServis.GetCurrent().MyFavoriteBooks;

            return View("Index", currentUserFavoriteBooks);
        }
    }
}
