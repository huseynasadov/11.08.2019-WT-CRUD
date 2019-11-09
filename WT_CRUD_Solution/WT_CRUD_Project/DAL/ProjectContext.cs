using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WT_CRUD_Project.Models;

namespace WT_CRUD_Project.DAL
{
    public class ProjectContext:DbContext
    {
        public ProjectContext():base("ProjectConnection")
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
    }
}