using Microsoft.AspNetCore.Mvc;
using Work01.Models.DAL;
using Work01.Models;
using System.Linq;
using Microsoft.CodeAnalysis;
using Work01.Models.ViewModel;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Work01.Controllers
{
    public class TrackerController : Controller
    {
        private readonly ExpenseTrackDbContaxt db;
        public TrackerController(ExpenseTrackDbContaxt context)
        {
                this.db=context;
        }
        public IEnumerable<UsersVM> uSers { get; set; }
        public IActionResult Index(DateTime startDate, DateTime endDate)
        {
            

            var users = (from u in db.Users
                         join c in db.Categories
                       on u.CategoryId equals c.CategoryId
                         select new UsersVM
                         {
                             Id = u.Id,
                             CategoryId = c.CategoryId,


                             ExpenseDate = u.ExpenseDate,
                             Amount = u.Amount,
                             Categories = c.Categories

                         }).ToList();


            


            //uSers = (from x in db.Users where (x.ExpenseDate <= startDate) && (x.ExpenseDate >= endDate) select x).ToList();

            return View(users);
        }
        public IActionResult Create()
        {
            ViewBag.categories=db.Categories.ToList();          
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                
               
            }
            ViewBag.categories = db.Categories.ToList();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            var users = db.Users.FirstOrDefault(x => x.Id == id);
           
            ViewBag.categories = db.Categories.ToList();
            return View(users);

            
        }
        [HttpPost]
        public IActionResult Edit(UsersVM vm)
        {
            if (ModelState.IsValid)
            {
                User u = new User
                {
                    Id= vm.Id,
                    CategoryId=vm.CategoryId,
                    ExpenseDate=vm.ExpenseDate,
                    Amount=vm.Amount,
                };



                db.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }            
            ViewBag.categories = db.Categories.ToList();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            var users = db.Users.FirstOrDefault(x => x.Id == id);
            ViewBag.categories = db.Categories.ToList();
            return View(users);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

            var users = db.Users.FirstOrDefault(x => x.Id == id);
            db.Entry(users).State =Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        //public IEnumerable<User> Users { get; set; }
        //public IActionResult GetData(DateTime startDate,DateTime endDate )
        //{
        //    Users = db.Users.ToList();

        //    //Users=(from x in db.Users where (x.ExpenseDate<=startDate)&&(x.ExpenseDate>=endDate)select x).ToList();

        //    return View(Users);
        //}
    }
}
