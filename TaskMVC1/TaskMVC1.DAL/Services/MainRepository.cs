using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMVC1.DAL.Abstracts;
using TaskMVC1.DAL.EF;

namespace TaskMVC1.DAL.Services
{
    /// <summary>
    /// Repository for work with any table.
    /// </summary>
    /// <typeparam name="T">DbSet type</typeparam>
    public class MainRepository<T> : Repository<T> where T : class
    {
        public MainRepository(BlogContext context):base(context)
        {
        }

        /// <summary>
        /// Create row.
        /// </summary>
        /// <param name="item">New row</param>
        public override void Create(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        /// <summary>
        /// Delete row.
        /// </summary>
        /// <param name="id">Row id</param>
        public override void Delete(int id)
        {
            T item = Get(id);
            if (item != null)
                _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        /// <summary>
        /// Return one row.
        /// </summary>
        /// <param name="id">Rowe id</param>
        /// <returns></returns>
        public override T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Show all rows.
        /// </summary>
        /// <returns></returns>
        public override ICollection<T> Show()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Update row.
        /// </summary>
        /// <param name="item">New row item</param>
        public override void Update(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
