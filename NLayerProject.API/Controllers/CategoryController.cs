using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.API.Filters;
using NLayerProject.Core.Service;
using NLayerProject.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto category)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(category));

            return Created("", _mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var a = _mapper.Map<Category>(categoryDto);
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;

            _categoryService.Remove(category);

            return NoContent();
        }
    }
}