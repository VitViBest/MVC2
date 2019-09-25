using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Entities
{
    /// <summary>
    /// Include user answers. 
    /// </summary>
    public class Questionary
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int? ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public virtual Complectation Complectation { get; set; }

        public int? ComplectationId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
