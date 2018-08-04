using System;
using GigHub.Models;
using GigHub.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewMode = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewMode);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var artistId = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == artistId);

            var gig = new Gig()
            {
                Venua = viewModel.Venua,
                Genre = _context.Genres.Single(g=>g.Id == viewModel.Genre),
                DateTime = DateTime.Parse($"{viewModel.Date} {viewModel.Time}"),
                Artist = artist
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}