using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TaskMVC1.DAL.Interfaces
{
    /// <summary>
    /// Create new field.
    /// </summary>
    /// <typeparam name="T">DbSet type</typeparam>
    public interface ICreator<T> where T:class
    {
        void Create(T item);
    }
}