using System.Collections.Generic;

namespace Graduate_work.Models
{
    public class NumberOfPagesPicture
    {
        public int NumberOfImg { get; set; }
        public int NumberOfPage { get; set; }
        public List<PictureViewModel> Pictures { get; set; }
    }
}
