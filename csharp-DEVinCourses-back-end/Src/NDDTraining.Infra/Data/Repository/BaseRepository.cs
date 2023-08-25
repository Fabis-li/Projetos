using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;

namespace NDDTraining.Infra.Data.Repository
{
  public class BaseRepository<TEntity, Tkey> where TEntity : class
  {
    protected readonly NDDTrainingDbContext _context;
    public BaseRepository(NDDTrainingDbContext context)
    {
      _context = context;
    }

    public virtual void Insert(TEntity entity)
    {
      _context.Set<TEntity>().Add(entity);
      _context.SaveChanges();
    }
    public virtual void Update(TEntity entity)
    {
      _context.Set<TEntity>().Update(entity);
      _context.SaveChanges();
    }

    public virtual TEntity GetById(Tkey id)
    {
      return _context.Set<TEntity>().Find(id);
    }

    public virtual IList<TEntity> GetAll(Paging paging)
    {
      return _context.Set<TEntity>()
                      .Take(paging.Take)
                      .Skip(paging.Skip)
                      .ToList();
    }

    public virtual void Delete(TEntity entity)
    {
      _context.Set<TEntity>().Remove(entity);
    }

    public virtual int ObterTotal()
    {
        return _context.Set<TEntity>().Count();
    }

  }
}