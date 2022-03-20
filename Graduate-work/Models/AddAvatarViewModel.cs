using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Graduate_work.Models
{
    public class AddAvatarViewModel
    {
        public string Url { get; set; }

        public IFormFile File { get; set; }
    }
}
