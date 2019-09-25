using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Entities
{
    /// <summary>
    /// Class for additional information.
    /// </summary>
    public class Tag
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Questionary> Questionaries { get; set; }
    }
}
