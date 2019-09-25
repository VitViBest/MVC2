using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Interfaces
{
    /// <summary>
    /// Display fields.
    /// </summary>
    /// <typeparam name="T">DbSet type</typeparam>
    public interface IDisplayer<T> where T:class
    {
        /// <summary>
        /// Displays all fields.
        /// </summary>
        /// <returns></returns>
        ICollection<T> Show();

        /// <summary>
        /// Return on field.
        /// </summary>
        /// <param name="id">Row id.</param>
        /// <returns></returns>
        T Get(int id);
    }
}
