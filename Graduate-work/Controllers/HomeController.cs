using AutoMapper;
using Graduate_work.EfStuff.Repositories;
using Graduate_work.Models;
using Graduate_work.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Graduate_work.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private PictureRepository _pictureRepository;
        private IMapper _mapper;
        private UserService _userServis;


        public HomeController(PictureRepository pictureRepository, IMapper mapper, UserService userServis)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
            _userServis = userServis;
        }

        public IActionResult Gallery(int pageNumber = 1)
        {
            var _defoultUrl = "/images/demo/gallery/01.png";
            var _numberOfPictures = 12;

            if (pageNumber > 3)
            {
                pageNumber -= 3;
            }
            else if (pageNumber == 3)
            {
                pageNumber -= 2;
            }
            else if (pageNumber == 0)
            {
                pageNumber = 1;
            }

            var _user = _userServis.GetCurrent();
            var viewModels = new List<PictureViewModel>();

            viewModels.AddRange(_mapper.Map<List<PictureViewModel>>(
                _pictureRepository.TakeAndSkipPicture(_user.Id, _numberOfPictures, _numberOfPictures * (pageNumber - 1))));
            var defoultPictureList = Enumerable.Range(1, _numberOfPictures - viewModels.Count).Select(x => new PictureViewModel(_defoultUrl));
            viewModels.AddRange(defoultPictureList);



            var NumberOfPagesPicture = new NumberOfPagesPicture()
            {
                Number = pageNumber,
                Pictures = viewModels
            };
            return View(NumberOfPagesPicture);
        }

        public IActionResult sliderData(int pageNumber = 1)
        {
            var _defoultPictureCollection = 50;
            var _user = _userServis.GetCurrent();
            var viewModels = new List<PictureViewModel>();
            viewModels.AddRange(_mapper.Map<List<PictureViewModel>>(
                _pictureRepository.TakeAndSkipPicture(_user.Id, _defoultPictureCollection, _defoultPictureCollection * (pageNumber - 1))));
            
            return new JsonResult(viewModels);
        }
        
        public IActionResult Slider()
        {
            return View();
        }
    }
}
