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

        public IActionResult Gallery(int pageNumber = 1, int numberOfPictures = 12)
        {
            var _numberOfPictures = numberOfPictures;
            var displayedLinks = pageNumber;
            if (displayedLinks - 2 > 0)
            {
                displayedLinks -= 1;
            }
            else
            {
                displayedLinks = 1;
            }

            var _user = _userServis.GetCurrent();
            var viewModels = new List<PictureViewModel>();

            viewModels.AddRange(_mapper.Map<List<PictureViewModel>>(
                _pictureRepository.TakeAndSkipPicture(_user.Id, _numberOfPictures, _numberOfPictures * (pageNumber - 1))));

            var NumberOfPagesPicture = new NumberOfPagesPicture()
            {
                NumberOfImg = numberOfPictures,
                NumberOfPage = displayedLinks,
                Pictures = viewModels
            };
            return View(NumberOfPagesPicture);
        }
        public IActionResult SliderData([FromQuery(Name = "Name")] string name)
        {
            var _userId = _userServis.GetCurrent().Id;
            var viewModels = new List<PictureViewModel>();
            var allImgs = _mapper.Map<List<PictureViewModel>>(
                _pictureRepository.GetAllUsersPictures(_userId));

            var selectImg = _mapper.Map<PictureViewModel>(
            _pictureRepository.GetByName(_userId, name));
            allImgs.Remove(selectImg);
            viewModels.Add(selectImg);
            viewModels.AddRange(allImgs);
            return new JsonResult(viewModels);
        }
        public IActionResult Slider([FromQuery(Name = "Name")] string name)
        {
            var _userId = _userServis.GetCurrent().Id;

            var selectImg = _mapper.Map<PictureViewModel>(
            _pictureRepository.GetByName(_userId, name));
 
            return View(selectImg);
        }
    }
}
