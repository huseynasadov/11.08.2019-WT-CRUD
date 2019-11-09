using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WT_CRUD_Project.Models;

namespace WT_CRUD_Project.ViewModels
{
    public class HomeCreateVM
    {
      public  IEnumerable<ProjectCategory> Categories { get; set; }
        public Project Project { get; set; }
    }
}