using Microsoft.AspNetCore.Mvc;
using ReadyPlayerOne.Models;
using Microsoft.EntityFrameworkCore;

namespace ReadyPlayerOne.Controllers
{
    public class FavoritesController : Controller
    {
        private PlayerContext context;

        public FavoritesController(PlayerContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var session = new PlayerSession(HttpContext.Session);
            var model = new PlayerViewModel
            {
                ActiveAlign = session.GetActiveAlign(),
                Players = session.GetMyPlayers()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(Player player)
        {
            // get full team data from database
            player = context.Players
           .Include(t => t.Alignment)
           .Where(t => t.PlayerID == player.PlayerID)
           .FirstOrDefault() ?? new Player();

            // add team to favorite teams in session and cookie
            var session = new PlayerSession(HttpContext.Session);
            var cookies = new PlayerCookies(Response.Cookies);

            var players = session.GetMyPlayers();
            players.Add(player);
            session.SetMyPlayers(players);
            cookies.SetMyPlayerIds(players);

            // set add message
            TempData["message"] = $"{player.PlayerName} added to your favorites";

            // redirect to Home page
            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveConf = session.GetActiveAlign(),

                });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            // delete favorite teams from session and cookie
            var session = new PlayerSession(HttpContext.Session);
            var cookies = new PlayerCookies(Response.Cookies);

            session.RemoveMyPlayers();
            cookies.RemoveMyPlayerIds();

            // set delete message
            TempData["message"] = "Party cleared";

            // redirect to Home page
            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveAlign = session.GetActiveAlign(),
                });
        }
    }
}
