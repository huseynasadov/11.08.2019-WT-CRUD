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
    public class ProjectController : Controller
    {
        private readonly ProjectContext _db;
        public ProjectController()
        {
            _db = new ProjectContext();
        }
        // GET: Project
        public ActionResult Index()
        {
            List<Project> projects = _db.Projects.Include("ProjectCategory").OrderByDescending(p => p.PublishDate).ToList();
            return View(projects);
        }

        [HttpGet]
        public ActionResult Create()
        {
            HomeCreateVM model = new HomeCreateVM {
                Categories = _db.ProjectCategories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (_db.Projects.Any(p=>p.Name == project.Name))
            {
                ModelState.AddModelError("Project.Name", project.Name + " adlı proyekt artıq movcuddur");
            }

            if (ModelState.IsValid)
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            HomeCreateVM model = new HomeCreateVM
            {
                Categories = _db.ProjectCategories.ToList(),
                Project = project
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Project project = _db.Projects.Find(id);
            if (project==null)
            {
                return HttpNotFound();
            }


            HomeCreateVM model = new HomeCreateVM {
                Project = project,
                Categories = _db.ProjectCategories.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (_db.Projects.Any(p => (p.Id != project.Id) && (p.Name == project.Name)))
            {
                ModelState.AddModelError("Project.Name", project.Name + " adlı proyekte deyisiklik edə biməzsiniz");
            }
            if (ModelState.IsValid)
            {
                _db.Entry(project).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            HomeCreateVM model = new HomeCreateVM
            {
                Project = project,
                Categories = _db.ProjectCategories.ToList()
            };

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            Project project = _db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            _db.Projects.Remove(project);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}