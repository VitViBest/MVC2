using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMVC1.DAL.Entities;

namespace TaskMVC1.Models.Home
{
    public class HomeIndexVM
    {
        public List<Article> Articles { get; set; }
    }
}