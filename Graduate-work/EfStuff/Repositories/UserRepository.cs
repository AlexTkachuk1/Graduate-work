using Graduate_work.Model;
using System.Linq;

namespace Graduate_work.EfStuff.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ProjectDbContext dbContext) 
            : base(dbContext)
        {
        }

        public User Get(string login, string password)
        {
            return _dbSet
                .SingleOrDefault(x => x.Login == login && x.Password == password);
        }

        public bool Exist(Role role)
        {
            return _dbSet.Any(x => x.Role == role);
        }
    }
}
