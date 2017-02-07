using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wikipages.Models;

namespace Wikipages.Controllers
{
    public class BusinessesController : Controller
    {
        private WikipagesContext db = new WikipagesContext();
        public IActionResult Index()
        {
            return View(db.Businesses.OrderByDescending(business => business.TypeId).ToList());
        }

        public IActionResult Details(int id)
        {
            Business foundBusiness = db.Businesses.FirstOrDefault(businesses => businesses.BusinessId == id);
            return View(foundBusiness);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Business business)
        {
            db.Businesses.Add(business);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
