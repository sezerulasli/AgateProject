using AgateProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace AgateProject.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();

        public List<T> List()
        {
            return c.Set<T>().ToList();
        }
        public void Add(T t)
        {
            c.Set<T>().Add(t);
            c.SaveChanges();
        }
        public void Delete(T t)
        {
            c.Set<T>().Remove(t);
            c.SaveChanges();
        }
        public void Update(T t)
        {
            c.Set<T>().Update(t);
            c.SaveChanges();
        }
        public T Get(int id)
        {
            return c.Set<T>().Find(id);
        }
        public List<T> List(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
    }
}
