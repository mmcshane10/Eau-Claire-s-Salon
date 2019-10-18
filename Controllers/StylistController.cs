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
    public class StylistsController : Controller
    {
        private readonly HairSalonContext _db;

        public StylistsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Stylist> model = _db.Stylists.ToList();
            model = model.OrderBy(s => s.Name).ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            List<Client> model = _db.Clients.Include(client => client.Stylist).ToList();
            Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistID == id);
            return View(thisStylist);
        }

        public ActionResult Edit(int id)
        {
            var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistID == id);
            return View(thisStylist);
        }

        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
            _db.Entry(stylist).State = EntityState.Modified;
            _db.SaveChanges();
            int id = stylist.StylistID;
            return RedirectToAction("Details", new { id });
        }

        public ActionResult Delete(int id)
        {
            var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistID == id);
            return View(thisStylist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistID == id);
            _db.Stylists.Remove(thisStylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}