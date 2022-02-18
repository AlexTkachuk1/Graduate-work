using Graduate_work.Model;
using Microsoft.AspNetCore.Http;

namespace Graduate_work.Models
{
    public class AddPictureViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public virtual User Creater { get; set; }

        public IFormFile File { get; set; }

        public AddPictureViewModel()
        {
        }

        public AddPictureViewModel(string url)
        {
            Url = url;
        }
    }
}
