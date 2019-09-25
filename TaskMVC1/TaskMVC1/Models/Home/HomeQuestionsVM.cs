using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskMVC1.DAL.Entities;

namespace TaskMVC1.Models.Home
{
    public class HomeQuestionsVM
    {
        public Dictionary<int,string> Complectations { get; set; }

        public Dictionary<int, string> Tags { get; set; }

        public SelectList Models { get; set; }
    }
}