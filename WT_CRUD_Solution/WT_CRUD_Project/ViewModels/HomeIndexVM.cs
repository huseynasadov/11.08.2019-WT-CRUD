using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WT_CRUD_Project.Models;

namespace WT_CRUD_Project.ViewModels
{
    public class HomeIndexVM
    {
        public List<Project> Projects { get; set; }
        public List<ProjectCategory> ProjectCategories { get; set; }
    }
}