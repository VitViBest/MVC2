using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Entities
{
    /// <summary>
    /// Table with articles.
    /// </summary>
    public class Article
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public byte[] Photo { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Questionary> Questionaries { get; set; }
    }
}
