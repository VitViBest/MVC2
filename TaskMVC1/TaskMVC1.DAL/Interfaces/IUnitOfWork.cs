using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMVC1.DAL.Abstracts;
using TaskMVC1.DAL.Entities;

namespace TaskMVC1.DAL.Interfaces
{
    /// <summary>
    /// Unit for work with database context.
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        Repository<Article> Articles { get; }

        Repository<Complectation> Complections { get; }

        Repository<Questionary> Questionaries { get; }

        Repository<Review> Reviews { get; }

        Repository<Tag> Tags { get; }

        void Save();
    }
}
