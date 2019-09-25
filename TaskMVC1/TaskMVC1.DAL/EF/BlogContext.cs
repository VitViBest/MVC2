using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMVC1.DAL.Entities;

namespace TaskMVC1.DAL.EF
{
    /// <summary>
    /// Context class for work with database.
    /// </summary>
    public class BlogContext : DbContext
    {
        /// <summary>
        /// Attach initializer.
        /// </summary>
        static BlogContext()
        {
            Database.SetInitializer<BlogContext>(new DbInitializer());
        }

        public BlogContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Complectation> Complectations { get; set; }

        public DbSet<Questionary> Questionaries { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
