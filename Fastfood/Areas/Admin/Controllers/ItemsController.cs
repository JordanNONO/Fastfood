using Fastfood.Repository;
using Fastfood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fastfood.Areas.Admin.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Items.Include(x => x.Category).Include(y=>y.SubCategory).ToList();
            return View(items);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ItemViewModel vm = new ItemViewModel();
            ViewBag.Category = new SelectList(_context.Categories, "Id", "Title");
            return View();
        }

        [HttpGet]
        public IActionResult GetSubCategory(int categoryId)
        {
            var subCategory = _context.SubCategories.Where(x=>x.CategoryId == categoryId).FirstOrDefault();

            return Json(subCategory);
        }

        [HttpGet]
        public async Task<ActionResult> Create(ItemViewModel vm)
        {
           if(ModelState.IsValid)
            {
               
            }
            return View(vm);
        }
    }
}
