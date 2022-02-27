using Graduate_work.Model;
using Microsoft.AspNetCore.Http;

namespace Graduate_work.Models
{
    public class PictureViewModel
    {
        public string Url { get; set; }

        public string Name { get; set; }
        public PictureViewModel(string url, string name)
        {
            Url = url;
            Name = name;
        }
    }
}
