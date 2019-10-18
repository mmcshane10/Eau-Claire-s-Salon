using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly HairSalonContext _db;

        public HomeController(HairSalonContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public ActionResult Search(string search)
        {
            List<Client> model = _db.Clients.Include(client => client.Stylist).ToList();
            Client thisClient = _db.Clients.FirstOrDefault(client => client.Name == search);
            return View("Search", thisClient);
        }
    }
}
