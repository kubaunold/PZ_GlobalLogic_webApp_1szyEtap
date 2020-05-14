using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorMobCRUD.Models;

namespace SensorMobCRUD.Controllers
{
    [Route("measurment")]
    public class HomeController : Controller
    {
        private readonly DataContext db;//= new DataContext();
        public HomeController(DataContext context)
        {
            db = context;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {

            ViewBag.Title = "Put yr page title here";
            ViewBag.Description = "Put your page description here";
            ViewBag.Measurments = db.Measurments.ToList();
            return View();
        }

        public async Task<IActionResult> ReturnMeasurements(int? id)
        {
            var gL_Sensors_v0_2Context = db.Measurments.Include(o => o.sensorId).Where(e => e.sensorId == id);
            return View(await gL_Sensors_v0_2Context.ToListAsync());
        }

        //razdwatrzy
        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Measurment measurment)
        {
            db.Measurments.Add(measurment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Measurments.Remove(db.Measurments.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", db.Measurments.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Measurment measurment)
        {
            db.Entry(measurment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("map")]
        public IActionResult Map()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
