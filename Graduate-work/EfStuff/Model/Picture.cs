using Graduate_work.Model;

namespace Graduate_work.EfStuff.Model
{
    public class Picture : BaseModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public virtual User Creater { get; set; }
    }
}
