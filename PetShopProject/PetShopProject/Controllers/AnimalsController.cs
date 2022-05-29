#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using PetShop.Service.Interfaces;

namespace PetShopProject.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ICatalogService _CatalogService;
        private readonly IAdminService _AdminService;
        private readonly ICommentService _CommentService;


        public AnimalsController(ICatalogService catalogService, IAdminService adminService, ICommentService commentService)
        {
            _AdminService = adminService;
            _CatalogService = catalogService;
            _CommentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var CatalogDataContext = _CatalogService.GetAllAnimals();
            return View(await CatalogDataContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int id)
        {
            ViewBag.AnimalComments = _CommentService.GetAllComments(id);
            var animal = await _CatalogService.GetAnimal(id);
            if (animal == null) return NotFound();
            return View(animal);
        }


        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_CatalogService.GetAllCatagories(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId,Name,Description,BirtheDate,PhotoUrl,CategoryId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                await _AdminService.CreateAnimal(animal);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_CatalogService.GetAllCatagories(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var animal = await _CatalogService.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_CatalogService.GetAllCatagories(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AnimalId,Name,Description,BirtheDate,PhotoUrl,CategoryId")] Animal animal)
        {
            if (id != animal.AnimalId) return NotFound();

            if (ModelState.IsValid)
            {
                _AdminService.Update(animal);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_CatalogService.GetAllCatagories(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _CatalogService.GetAnimal(id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var A = await _AdminService.GetAnimal(id);
            if (A != null)
            {
                await _AdminService.DeleteAnimal(A);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _CatalogService.GetAnimal(id) == null;
        }
        public async Task<IActionResult> DeleteComment(int itemId)
        {
            var deletedComment = await _CommentService.RemoveComment(itemId);
            return RedirectToAction("Details", new { id = deletedComment.AnimalId });
        }

    }
}
