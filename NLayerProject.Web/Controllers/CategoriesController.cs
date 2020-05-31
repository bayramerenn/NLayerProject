using Microsoft.AspNetCore.Mvc;
using NLayerProject.Web.ApiService;
using NLayerProject.Web.DTOs;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();

            return View(categories);
        }

        //public async Task<IActionResult> Index(string id)
        //{
        //    var categories = await _categoryApiService.GetByIdAsync(id);

        //    return View(categories);
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var category =await _categoryApiService.GetByIdAsync(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            await _categoryApiService.Delete(id);
             
            return RedirectToAction("Index");
        }

       
    }
}