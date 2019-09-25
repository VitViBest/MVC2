using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Interfaces
{
    /// <summary>
    /// Remove field from table.
    /// </summary>
    /// <typeparam name="T">DbSet type</typeparam>
    public interface IRemover 
    {
        void Delete(int id);
    }
}
