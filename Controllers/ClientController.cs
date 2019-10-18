using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public ActionResult Edit(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(client => client.ClientID == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistID", "Name");
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            int id = client.StylistID;
            return RedirectToAction("Details", "Stylists", new { id });
        }

        public ActionResult Delete(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientID == id);
            return View(thisClient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientID == id);
            _db.Clients.Remove(thisClient);
            id = thisClient.StylistID;
            _db.SaveChanges();
            return RedirectToAction("Details", "Stylists", new { id });
        }

        
    }
}