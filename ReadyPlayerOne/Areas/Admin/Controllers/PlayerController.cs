using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadyPlayerOne.Models;

namespace ReadyPlayerOne.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlayerController : Controller
    {
        
        private PlayerContext context { get; set; }

        public PlayerController(PlayerContext ctx) => context = ctx;

        [AllowAnonymous]
        public IActionResult Catalogue()
        {
            var players = context.Players.OrderBy(
            m => m.PlayerName).ToList();
            return View(players);
        }
        
        [Route("[area]/[controller]s/{id?}")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            //Adding Player Images
            ViewBag.PlayerImages = context.PlayerImages.OrderBy(p => p.Image).ToList();
            ViewBag.AlignmentTypes = context.Alignments.ToList();
            ViewBag.PlayerImages = context.PlayerImages.ToList();
            return View("Edit", new Player());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            //Adding Player Images
            ViewBag.PlayerImages = context.PlayerImages.OrderBy(p => p.Image).ToList();
            ViewBag.AlignmentTypes = context.Alignments.ToList();
            ViewBag.PlayerImages = context.PlayerImages.ToList();
            var player = context.Players.Find(id);
            return View(player);
        }
        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                if (player.PlayerID == 0)
                    context.Players.Add(player);
                else
                    context.Players.Update(player);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action =
                    (player.PlayerID == 0) ? "Add" : "Edit";
                //Adding Player Images
                ViewBag.PlayerImages = context.PlayerImages.OrderBy(p => p.Image).ToList();
                ViewBag.AlignmentTypes = context.Alignments.ToList();
                ViewBag.PlayerImages = context.PlayerImages.ToList();
                return View(player);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var player = context.Players.Find(id);
            return View(player);
        }
        [HttpPost]
        public IActionResult Delete(Player player)
        {
            context.Players.Remove(player);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: /Player/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.AlignmentTypes = context.Alignments.ToList();
            ViewBag.PlayerImages = context.PlayerImages.ToList();
            return View("Edit", new Player());
        }

        // POST: /Player/Create
        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                context.Players.Add(player);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Action = "Create";
            ViewBag.AlignmentTypes = context.Alignments.ToList();
            ViewBag.PlayerImages = context.PlayerImages.ToList();
            return View("Edit", player);
        }

    }
}

