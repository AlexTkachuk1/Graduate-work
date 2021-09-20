using AutoMapper;
using Graduate_work.EfStuff.Model;
using Graduate_work.EfStuff.Repositories;
using Graduate_work.Models;
using Graduate_work.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Graduate_work.Controllers
{
    public class PictureController : Controller
    {
        private PictureRepository _pictureRepository;
        private IMapper _mapper;
        private UserService _userServis;
        private FileService _fileService;

        public PictureController(PictureRepository pictureRepository, IMapper mapper, UserService userServis, FileService fileService)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
            _userServis = userServis;
            _fileService = fileService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddPictureViewModel viewModel)
        {
            var picture = _mapper.Map<Picture>(viewModel);
            picture.Creater = _userServis.GetCurrent();
            _pictureRepository.Save(picture);

            var path = _fileService.GetPath(picture.Id);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                viewModel.File.CopyTo(fileStream);
            }

            picture.Url = _fileService.GetUrl(picture.Id);
            _pictureRepository.Save(picture);

            return RedirectToAction("Gallery", "Home");
        }

        public IActionResult Remove(long id)
        {
            _pictureRepository.Remove(id);

            System.IO.File.Delete(_fileService.GetPath(id));

            return RedirectToAction("Gallery", "Home");
        }

    }
}
