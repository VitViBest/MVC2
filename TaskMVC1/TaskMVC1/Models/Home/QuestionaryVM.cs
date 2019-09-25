using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMVC1.Models.Home
{
    public class QuestionaryVM
    {
        public string Name { get; set; }

        public string Age { get; set; }

        public int? Model { get; set; }

        public int? Complectation { get; set; }

        public int[] Additional { get; set; }
    }
}