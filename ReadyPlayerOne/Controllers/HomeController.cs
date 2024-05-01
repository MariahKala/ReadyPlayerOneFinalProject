using Microsoft.AspNetCore.Mvc;
using ReadyPlayerOne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace ReadyPlayerOne.Controllers
{
    public class HomeController : Controller
    {
        private PlayerContext _context;

        public HomeController(PlayerContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index(PlayerViewModel model)
        {
            var session = new PlayerSession(HttpContext.Session);
            session.SetActiveAlign(model.ActiveAlign);

            int? count = session.GetMyPlayerCount();
            if (!count.HasValue)
            {
                var cookies = new PlayerCookies(Request.Cookies);
                string[] ids = cookies.GetMyPlayerIds();

                if (ids.Length > 0)
                {
                    var myplayers = _context.Players
                        .Include(t => t.Alignment)
                        .Where(t => ids.Contains(t.PlayerID.ToString()))
                        .ToList();
                    session.SetMyPlayers(myplayers);
                }
            }

            model.Alignments = _context.Alignments.ToList();
            model.PlayerImages = _context.PlayerImages.ToList();

            IQueryable<Player> query = _context.Players.OrderBy(p => p.PlayerName);
            if (model.ActiveAlign != "all")
            {
                query = query.Where(p => p.Alignment.AlignmentID == model.ActiveAlign); ;
            }
            model.Players = query.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var session = new PlayerSession(HttpContext.Session);
            var model = new PlayerViewModel
            {
                Player = _context.Players
                        .Include(t => t.Alignment)
                        .Include(t => t.PlayerImage) //Excluding just to see
                        .FirstOrDefault(t => t.PlayerID == id) ?? new Player(), //This should be PlayerID, but there is an issue as it compares an Int and a String
                ActiveAlign = session.GetActiveAlign()
            };
            return View(model);
        }
    }
}