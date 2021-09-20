using AutoMapper;
using Graduate_work.EfStuff.Repositories;
using Graduate_work.Models;
using Graduate_work.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private PictureRepository _pictureRepository;
        private IMapper _mapper;
        private UserService _userServis;
        private const string _defoultUrl = "/images/demo/gallery/01.png";

        public HomeController(PictureRepository pictureRepository, IMapper mapper, UserService userServis)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
            _userServis = userServis;
        }

        public IActionResult Gallery(int pageNumber=1)
        {
            var viewModels = _mapper.Map<List<AddPictureViewModel>>(_pictureRepository.GetAll());
            var count = viewModels.Count;
            var allPages = new List<NumberOfPagesPicture>();
            if (12>count)
            {
                for (int i = 0; i < 12- count; i++)
                {
                    var defoultPicture = new AddPictureViewModel()
                    {
                        Url = _defoultUrl
                    };
                    viewModels.Add(defoultPicture);
                }
                var page = new NumberOfPagesPicture()
                {
                    Number = 1,
                    Pictures = viewModels
                };
                allPages.Add(page);
            }
            if (12<count)
            {
                var numberOfPages = count / 12 + 1;
                for (int i = 0; i < numberOfPages; i++)
                {
                    var pictures = viewModels.Skip(0 + i).Take(12).ToList();
                    var page = new NumberOfPagesPicture()
                    {
                        Number = i + 1,
                        Pictures = pictures
                    };
                    allPages.Add(page);
                }
            }
            if (allPages.Count< pageNumber)
            {
                var defoultPage = new List<AddPictureViewModel>();
                for (int i = 0; i < 12; i++)
                {
                    defoultPage.Add(new AddPictureViewModel()
                    {
                        Url = _defoultUrl
                    });
                }
                for (int i = pageNumber- allPages.Count; i < pageNumber+1; i++)
                {
                    var newPage = new NumberOfPagesPicture()
                    {
                        Number = i,
                        Pictures = defoultPage

                    };
                }
            }
            var viewPage = allPages.First(x => x.Number == pageNumber).Pictures;
            return View(viewPage);
        }

        public IActionResult MyGallery()
        {
            var viewModels = _mapper.Map<List<AddPictureViewModel>>(_userServis.GetCurrent().PicturesCreatedByMe);
            return View(viewModels);
        }
    }
}
