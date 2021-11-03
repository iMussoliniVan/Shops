using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db;
        public HomeController(ShopContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Shops.Include(u => u.ProductsLink).ToListAsync());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.ShopId = id;
            var users = db.Shops.Include(u => u.ProductsLink).ToList();
            return View(users[id-1]);
        }

        [HttpPost]
        public string Buy(Product prod)
        {
            Product New = new Product { Name = prod.Name, Description = prod.Description, shop = db.Shops.Find(prod.ShopID) }; // Костыль, но я не заю как по другому сделать
            db.Products.Add(New);
            db.SaveChanges();
            return "Товар " + New.Name + " Был добавлен";
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            ViewBag.productId = id;
            return View();
        }

        [HttpPost]
        public string Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return "Товар был удален";
        }
        [HttpGet]
        public IActionResult Redact(int? id)
        {
            ViewBag.productId = id;
            return View();
        }

        [HttpPost]
        public string Redact(int Id, string Name, string Description)
        {
            db.Products.Find(Id).Name = Name;
            db.Products.Find(Id).Description = Description;
            db.SaveChanges();
            return "Товар был отредактирован";
        }
    }
}