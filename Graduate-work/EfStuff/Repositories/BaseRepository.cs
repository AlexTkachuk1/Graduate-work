using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graduate_work.Model;
using Graduate_work.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduate_work.EfStuff.Repositories
{
    public abstract class BaseRepository<Model>
    where Model : BaseModel
    {
        protected ProjectDbContext _projectDbContext;
        protected DbSet<Model> _dbSet;

        public BaseRepository(ProjectDbContext dbContext)
        {
            _projectDbContext = dbContext;
            _dbSet = _projectDbContext.Set<Model>();
        }

        public Model Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Model> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Save(Model model)
        {
            if (model.Id > 0)
            {
                _projectDbContext.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }

            _projectDbContext.SaveChanges();
        }

        public void Remove(Model model)
        {
            _dbSet.Remove(model);
            _projectDbContext.SaveChanges();
        }

        public void Remove(long id)
        {
            Remove(Get(id));
        }

        public int Count()
        {
            return _dbSet.Count();
        }
    }
}

