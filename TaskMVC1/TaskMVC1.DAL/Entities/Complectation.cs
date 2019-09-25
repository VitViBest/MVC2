using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMVC1.DAL.Entities
{
    /// <summary>
    /// Complecatation of car.
    /// </summary>
    public class Complectation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Questionary> Questionaries { get; set; }
    }
}
