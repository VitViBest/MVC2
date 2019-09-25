using System.Collections.Generic;
using TaskMVC1.DAL.EF;
using TaskMVC1.DAL.Interfaces;


namespace TaskMVC1.DAL.Abstracts
{
    /// <summary>
    /// Template of repository for work with DB table.
    /// </summary>
    /// <typeparam name="T">DbSet type</typeparam>
    public abstract class Repository<T>:IDisplayer<T>, IRemover, IUpdateer<T>,ICreator<T> where T:class
    {
        protected BlogContext _context;

        public Repository(BlogContext context)
        {
            _context = context;
        }

        public abstract void Create(T item);

        public abstract void Delete(int id);

        public abstract T Get(int id);

        public abstract ICollection<T> Show();

        public abstract void Update(T item);
    }
}
