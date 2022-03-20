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
using System.IO;
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
        private FileService _fileService;

        public UserController(UserRepository userRepository,
            IMapper mapper,
            UserService userServis,
            FileService fileService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userServis = userServis;
            _fileService = fileService;
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
        public IActionResult BlockedPage()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            var user = _userServis.GetCurrent();
            if (user.ProfileIsBlocked == true)
            {
                return RedirectToAction("BlockedPage");
            }
            var profileViewModel = _mapper.Map<ProfileViewModel>(user);
            return View(profileViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddData()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddAvatar()
        {

            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddAvatar(AddAvatarViewModel addAvatarViewModel)
        {
            var user = _userServis.GetCurrent();
            if (addAvatarViewModel.Url != null)
            {
                user.AvatarUrl = addAvatarViewModel.Url;
            }
            else
            {
                var id = Guid.NewGuid();
                var path = _fileService.GetPathForAvatar(id);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    addAvatarViewModel.File.CopyTo(fileStream);
                }
                user.AvatarUrl = $"/images/avatar/{id}.png";
                _userRepository.Save(user);
            }
            return RedirectToAction("Profile");
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddData(AddDataViewModel addDataViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddData", addDataViewModel);
            }
            var user = _userServis.GetCurrent();

            user.Email = addDataViewModel.Email != null ? addDataViewModel.Email : "Данные не указанны";
            user.Tel = addDataViewModel.Tel != null ? addDataViewModel.Tel : "xxx xx xxxxxxx";
            user.homeСity = addDataViewModel.homeСity != null ? addDataViewModel.homeСity : "Данные не указанны";
            user.homeСountry = addDataViewModel.homeСountry != null ? addDataViewModel.homeСountry : "Данные не указанны";
            user.FirstName = addDataViewModel.FirstName;
            user.LastName = addDataViewModel.LastName;

            _userRepository.Save(user);

            return RedirectToAction("Profile");
        }

        [HttpGet]
        [OnliAdmin]
        public IActionResult AllUsersAndRoles()
        {
            var allUsers = _userRepository.GetAllUsers();
            var allUsersRolsViewModel = new List<UserRoleViewModel>();
            foreach (var user in allUsers)
            {
                var userRoleViewModel = new UserRoleViewModel()
                {
                    Role = user.Role,
                    Login = user.Login,
                    ProfileIsBlocked = user.ProfileIsBlocked
                };
                allUsersRolsViewModel.Add(userRoleViewModel);
            }
            return View(allUsersRolsViewModel);
        }

        [HttpGet]
        [Authorize]
        [OnliAdmin]
        public IActionResult ChangeProfileIsBlocked()
        {
            return View();
        }

        [HttpPost]
        [OnliAdmin]
        public IActionResult ChangeProfileIsBlocked(ProfileIsBlockedViewModel profileIsBlockedViewModel)
        {
            var user = _userRepository.GetByLogin(profileIsBlockedViewModel.Login);
            user.ProfileIsBlocked = profileIsBlockedViewModel.ProfileIsBlocked;
            _userRepository.Save(user);
            return RedirectToAction("AllUsersAndRoles");
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
            if (!ModelState.IsValid)
            {
                return View("ChangeRole", changeRoleViewModel);
            }
            var rolValue = (int)Enum.Parse(typeof(Role), changeRoleViewModel.Role);
            var user = _userRepository.GetByLogin(changeRoleViewModel.Login);
            user.Role = (Role)rolValue;
            _userRepository.Save(user);
            return View("Index");
        }

        public IActionResult IsUniq(string name)
        {
            var isUniq = !_userRepository.Exist(name);
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
