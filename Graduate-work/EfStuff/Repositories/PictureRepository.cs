using Graduate_work.EfStuff.Model;
using System.Collections.Generic;
using System.Linq;

namespace Graduate_work.EfStuff.Repositories
{
    public class PictureRepository : BaseRepository<Picture>
    {
        public PictureRepository(ProjectDbContext dbContext)
            : base(dbContext)
        {
        }
        public List<Picture> TakeAndSkipPicture(long userId ,int take, int skip = 0)
        {
            return _dbSet.Where(x => x.Creater.Id == userId).Skip(skip).Take(take).ToList();
        }
    }
}
