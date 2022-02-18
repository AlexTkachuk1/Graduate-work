using Graduate_work.EfStuff.Model;
using System.Collections.Generic;

namespace Graduate_work.Model
{
    public class Book : BaseModel
    {
        public string Name { get; set; }

        public virtual User Reader { get; set; }
    }
}
