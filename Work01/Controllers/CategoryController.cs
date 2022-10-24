using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Work01.Models;
using Work01.Models.DAL;
using Work01.Models.ViewModel;

namespace Work01.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ExpenseTrackDbContaxt db;
        public CategoryController(ExpenseTrackDbContaxt db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(Category cat)
        {
            var item = cat.Categories;
            var duplicate = (from c in db.Categories
                             where
                           c.Categories == item
                             select c).ToList();
            if(duplicate.Count >= 1)
            {
                //var message = "This Category is Inserted!!(Not Allowed)";
                //throw new InvalidOperationException(message);
                return PartialView("_Invalid");
            }
            else
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                
            }

            return View(cat);
        }
        public IActionResult Edit(int? id)
        {
            var item = db.Categories.FirstOrDefault(x=>x.CategoryId==id);
            return View(item);


        }
        [HttpPost]
        public IActionResult Edit(UsersVM vm,Category cat)
        {
            var item = cat.Categories;
            var duplicate = (from c in db.Categories
                             where
                           c.Categories == item
                             select c).ToList();
            if (duplicate.Count >= 1)
            {
                //var message = "This Category is Inserted!!(Not Allowed)";
                //throw new InvalidOperationException(message);
                return PartialView("_Invalid");
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Category cats = new Category
                    {
                        CategoryId = vm.CategoryId,
                        Categories = vm.Categories,

                    };
                    db.Entry(cat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
                return View(cat);

            }


           



            //if (ModelState.IsValid)
            //{
            //    Category cat = new Category
            //    {
            //        CategoryId = vm.CategoryId,
            //        Categories = vm.Categories,

            //    };
            //    db.Entry(cat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //    db.SaveChanges();

            //}
            //return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            db.Remove(cat);
            db.SaveChanges();

            return View();

        }

    }
}
