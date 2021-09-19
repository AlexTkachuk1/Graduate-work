using Graduate_work.Model;
using Graduate_work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
