using Graduate_work.Model;
using Microsoft.AspNetCore.Http;

namespace Graduate_work.Models
{
    public class PictureViewModel
    {

        public string Url { get; set; }

        public PictureViewModel()
        {
        }

        public PictureViewModel(string url)
        {
            Url = url;
        }
    }
}
