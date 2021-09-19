using AutoMapper;
using Graduate_work.EfStuff.Repositories;
using Graduate_work.Model;
using Graduate_work.Models;
using Graduate_work.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            return View();
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
            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Denied()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            var User = _userServis.GetCurrent();
            return View();
        }
    }
}
