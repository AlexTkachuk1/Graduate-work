using Graduate_work.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.EfStuff.Repositories
{
    public class PictureRepository : BaseRepository<Picture>
    {
        public PictureRepository(ProjectDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
