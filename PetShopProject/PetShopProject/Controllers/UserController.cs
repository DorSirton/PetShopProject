using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using PetShop.Service.Interfaces;

namespace PetShopProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ICatalogService _CatalogService;
        private readonly ICommentService _CommentService;

        public UserController(ICatalogService catalogService, ICommentService commentService)
        {
            _CatalogService = catalogService;
            _CommentService = commentService;
        }
        public async Task<IActionResult> Index()
        {
            var CatalogDataContext = _CatalogService.GetAllAnimals();
            return View(await CatalogDataContext.ToListAsync());
        }
        public async Task<IActionResult> AddComment(Animal animal, [Bind("myComment")] string myComment)
        {
            if (myComment != null)
            {
                var comment = new Comment { AnimalId = animal.AnimalId, CommentContent = myComment };
                await _CommentService.AddComment(comment);
            }
            return RedirectToAction("Details", "Animals", new { id = animal.AnimalId });
        }
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.AnimalComments = _CommentService.GetAllComments(id);
            var animal = await _CatalogService.GetAnimal(id);
            if (animal == null) return NotFound();
            return View(animal);
        }

    }
}
