using EComerrce.IRepository;
using EComerrce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerrce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Create(category);
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = _categoryRepository.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                existingCategory.Name = category.Name;

                _categoryRepository.Update(existingCategory);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedCategory = _categoryRepository.Delete(id);
            if (deletedCategory == null)
            {
                return NotFound();
            }
            return Ok(deletedCategory);
        }

        [HttpGet("{id}/products")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            var products = _productRepository.GetProductsByCategoryId(id);
            return Ok(products);
        }
        [HttpGet("filter")]
        public IActionResult FilterProducts([FromQuery] string[] brands, decimal minPrice, decimal maxPrice, int rating)
        {
            var filteredProducts = _productRepository.FilterProducts(brands, minPrice, maxPrice, rating);
            return Ok(filteredProducts);
        }




    }
}
