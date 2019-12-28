using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project4.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Net;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project4.Controllers
{
    public class ArtistController : Controller
    {
        BookContext db;
        public ArtistController(BookContext context)
        {
            db = context;
        }


        public IActionResult Artist(string? text)
        {
            if (text != null && text.Trim() != "") {
                var artists = db.Authors
                .Where(c => c.Name.Contains(text) ||
                    c.Country.Contains(text));

                return View(artists);
            } else {
                return View(db.Authors.ToList());
            }
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author artist)
        {
            db.Authors.Add(artist);
            db.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Author artist = db.Authors.Find(ID);
            if (artist == null) {
                return new NotFoundResult();
            }
            db.Authors.Remove(db.Authors.Find(ID));
            db.SaveChanges();
            return Redirect("/Artist/Artist");
        }

        public IActionResult Detail(int? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Author artist = db.Authors.Find(ID);
            if (artist == null) {
                return new NotFoundResult();
            }
            ViewBag.Name = artist.Name;
            ViewBag.ID = artist.ID;
            ViewBag.Country = artist.Country;
            ViewBag.Name = artist.Name;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Author artist = db.Authors.Find(ID);
            if (artist == null) {
                return new NotFoundResult();
            }
            ViewBag.Name = artist.Name;
            ViewBag.ID = artist.ID;
            ViewBag.Country = artist.Country;
            ViewBag.Name = artist.Name;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Author artist)
        {
            if (artist == null) {
                return new BadRequestResult();
            }

            Author artist2 = db.Authors.Find(artist.ID);
            artist2.Country = artist.Country;
            artist2.Name = artist.Name;
            db.SaveChanges();

            return Redirect("/Artist/Artist");
        }

    }
}
