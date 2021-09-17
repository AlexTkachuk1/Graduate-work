using AutoMapper;
using Graduate_work.EfStuff.Repositories;
using Graduate_work.Model;
using Graduate_work.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graduate_work.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        private IMapper _mapper;

        public UserController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
    }
}
