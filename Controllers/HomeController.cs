using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllUsers = dbContext.Dish.ToList();
            List<Dish> MostRecent = dbContext.Dish
                .OrderByDescending(u => u.CreatedAt)
                .ToList();
            return View("Index", AllUsers);
        }
        
        [HttpGet("chef")]
        public IActionResult Chefs()
        {
            List<Chef> AllUsers = dbContext.Chef.ToList();
            List<Chef> MostRecent = dbContext.Chef.Include( c => c.CreatedDishes)
                .OrderByDescending(u => u.CreatedAt)
                .ToList();
            return View("ChefIndex", AllUsers);
        }

        [HttpGet("chef/new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View("New");
        }

        [HttpPost("chef/create")]
        public IActionResult CreateChef(Chef NewChef)
        {

            if(ModelState.IsValid)
            {
                dbContext.Add(NewChef);
                dbContext.SaveChanges();
                return RedirectToAction("NewChef");
            }
            else
            {
                return View("NewChef");
            }
        }

        [HttpPost("create")]
        public IActionResult CreateUser(Dish NewDish)
        {

            if(ModelState.IsValid)
            {
                dbContext.Add(NewDish);
                //this_chef = Grab Chef object where NewDish.Chef == Chef.Name;
                //NewDish.ChefId=this_chef.Id
                NewDish.ChefId = 1;
                dbContext.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("Hello");

                return View("New");
            }
        }

        [HttpGet("/info/{dishId}")]
        public IActionResult Info(int dishId)
        {
            
            Dish ClickedDish = dbContext.Dish.FirstOrDefault( d => d.DishId == dishId);
            return View("Info",ClickedDish);
            
        }
    
    }
}
