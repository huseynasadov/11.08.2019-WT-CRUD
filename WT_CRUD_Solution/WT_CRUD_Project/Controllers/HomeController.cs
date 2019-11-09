using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WT_CRUD_Project.DAL;
using WT_CRUD_Project.Models;
using WT_CRUD_Project.ViewModels;

namespace WT_CRUD_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectContext _db;
            public HomeController()
        {
            _db = new ProjectContext();
        }
        public ActionResult Index()
        {
            HomeIndexVM model = new HomeIndexVM {
                Projects = _db.Projects.Include("ProjectCategory").OrderByDescending(pr => pr.PublishDate).ToList(),
                ProjectCategories = _db.ProjectCategories.Include("Projects").OrderByDescending(pr=>pr.Projects.OrderByDescending(p=>p.PublishDate).FirstOrDefault().PublishDate).ToList()
        };
            return View(model);
        }
    }
}