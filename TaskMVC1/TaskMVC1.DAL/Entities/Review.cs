using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Entities
{
    /// <summary>
    /// For reviews table.
    /// </summary>
    public class Review
    {
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
