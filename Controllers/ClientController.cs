using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            ViewBag.StylistID = new SelectList(_db.Stylists, "StylistID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            int id = client.StylistID;
            return RedirectToAction("Details", "Stylists", new { id });
        }

        public ActionResult Details(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientID == id);
            return View(thisClient);
        }
    }
}