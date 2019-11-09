using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WT_CRUD_Project.DAL;
using WT_CRUD_Project.Models;

namespace WT_CRUD_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProjectContext _db;
        public CategoryController()
        {
            _db = new ProjectContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProjectCategory> categories = _db.ProjectCategories.Include("Projects").OrderByDescending(pr => pr.Projects.OrderByDescending(p => p.PublishDate).FirstOrDefault().PublishDate).ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectCategory projectCategory)
        {
            if (_db.ProjectCategories.Any(p => p.Name == projectCategory.Name))
            {
                ModelState.AddModelError("Name", projectCategory.Name + " adlı kateqoriya artıq movcuddur");
            }

            if (ModelState.IsValid)
            {
                _db.ProjectCategories.Add(projectCategory);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

           
            return View(projectCategory);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ProjectCategory category = _db.ProjectCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(ProjectCategory category)
        {
            if (_db.ProjectCategories.Any(p => (p.Id != category.Id) && (p.Name == category.Name)))
            {
                ModelState.AddModelError("Name", category.Name + " adlı kateqoriyaya deyisiklik edə biməzsiniz");
            }
            if (ModelState.IsValid)
            {
                _db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            ProjectCategory category = _db.ProjectCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            _db.ProjectCategories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}