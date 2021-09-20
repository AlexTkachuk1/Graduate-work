using Graduate_work.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.Models
{
    public class AddPictureViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public virtual User Creater { get; set; }

        public IFormFile File { get; set; }
    }
}
