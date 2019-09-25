using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Interfaces
{
    /// <summary>
    /// Update table.
    /// </summary>
    /// <typeparam name="T">DbSet type</typeparam>
    public interface IUpdateer<T> where T:class
    {
        void Update(T item);
    }
}
