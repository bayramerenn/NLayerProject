using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.API.Filters;
using NLayerProject.Core.Service;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Entity.Concrete;
using NLayerProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService ssservice { get; set; }

        public ProductController(IProductService productService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _productService = productService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("Dataları çekerken bir hata oluştu");

            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        // [ServiceFilter(typeof(NotFoundFilter))]

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryByIdAsync(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var saveProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            await _unitOfWork.CommitAsync();

            return Created(string.Empty, saveProduct);
        }

        //[ValidationFilter]
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var productUpdate = _productService.Update(_mapper.Map<Product>(productDto));

            _unitOfWork.Commit();

            return Ok(productUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _productService.GetByIdAsync(id).Result;

            _productService.Remove(product);

            return NoContent();
        }
    }
}