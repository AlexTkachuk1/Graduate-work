using Graduate_work.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.EfStuff.Model
{
    public class Comment : BaseModel
    {
        public string Contents { get; set; }

        public virtual User Creater { get; set; }
    }
}
