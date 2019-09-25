using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMVC1.DAL.Abstracts;
using TaskMVC1.DAL.EF;
using TaskMVC1.DAL.Entities;
using TaskMVC1.DAL.Interfaces;

namespace TaskMVC1.DAL.Services
{
    /// <summary>
    /// Unit for work with all tables in database.
    /// </summary>
    public class UnitOfWork: IUnitOfWork
    {
        private BlogContext _context;

        public UnitOfWork(string connectionString)
        {
            _context = new BlogContext(connectionString);
        }

        private Repository<Article> _articles;

        private Repository<Complectation> _complections;

        private Repository<Questionary> _questionaries;

        private Repository<Review> _reviews;
    
        private Repository<Tag> _tags;

        public virtual Repository<Article> Articles
        {
            get
            {
                if (_articles == null)
                    _articles = new MainRepository<Article>(_context);
                return _articles;
            }
        }

        public virtual Repository<Complectation> Complections
        {
            get
            {
                if (_complections == null)
                    _complections = new MainRepository<Complectation>(_context);
                return _complections;
            }
        }

        public virtual Repository<Questionary> Questionaries
        {
            get
            {
                if (_questionaries == null)
                    _questionaries = new MainRepository<Questionary>(_context);
                return _questionaries;
            }
        }

        public virtual Repository<Review> Reviews
        {
            get
            {
                if (_reviews == null)
                    _reviews = new MainRepository<Review>(_context);
                return _reviews;
            }
        }

        public virtual Repository<Tag> Tags
        {
            get
            {
                if (_tags == null)
                    _tags = new MainRepository<Tag>(_context);
                return _tags;
            }
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
