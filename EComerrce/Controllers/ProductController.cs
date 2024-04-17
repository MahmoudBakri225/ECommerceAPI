using EComerrce.DTO;
using EComerrce.IRepository;
using EComerrce.Models;
using EComerrce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerrce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var Products = ProductRepository.GetAll();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public IActionResult GetById(int id)
        {
            var Product = ProductRepository.GetById(id);
            if (Product != null)
            {
                return Ok(Product);
            }

            return BadRequest();
        }
       
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.Create(product);
                return Created($"https://localhost:7272/api/Product/{product.Id}", product);

            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var Product = ProductRepository.GetById(id);
                if (Product == null)
                {
                    return NotFound();
                }

                Product.Name = productDTO.Name;
                Product.Description = productDTO.Description;
                Product.Price = productDTO.Price;
                Product.Discount = productDTO.Discount;
                Product.Model = productDTO.Model;
                Product.CategoryID = productDTO.CategoryID;

                var updatedProduct = ProductRepository.Update(Product);
                return Ok(updatedProduct);
            }

            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleted = ProductRepository.Delete(id);

            if (deleted != null)
            {
                return Ok(deleted);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return BadRequest("Search text cannot be empty.");
            }

            var movies = ProductRepository.GetAll().Where(m => m.Name.Contains(searchText)).ToList();

            if (movies.Count == 0)
            {
                return NotFound("No movies found matching the search.");
            }

            return Ok(movies);
        }
        [HttpGet("filter")]
        public IActionResult FilterProducts([FromQuery] string[] brands, decimal minPrice, decimal maxPrice, int rating)
        {
            var filteredProducts = ProductRepository.FilterProducts(brands, minPrice, maxPrice, rating);

            var products = filteredProducts.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                // إضافة المزيد من الخصائص حسب الحاجة
            }).ToList();

            var categoryNames = filteredProducts.Select(p => p.Category.Name).Distinct().ToList();

            var minPriceResult = filteredProducts.Min(p => p.Price);
            var maxPriceResult = filteredProducts.Max(p => p.Price);
            var minRatingResult = filteredProducts.Min(p => p.Rating);
            var maxRatingResult = filteredProducts.Max(p => p.Rating);

            // إنشاء كائن يحتوي على قائمة المنتجات المصفاة
            var productsResult = new
            {
                Products = products
            };

            // إنشاء كائن يحتوي على قائمة أسماء الفئات
            var categoryNamesResult = new
            {
                CategoryNames = categoryNames
            };

            // إنشاء كائن للحد الأدنى والأقصى للأسعار
            var priceRangeResult = new
            {
                MinPrice = minPriceResult,
                MaxPrice = maxPriceResult
            };

            // إنشاء كائن للحد الأدنى والأقصى للتقييم
            var ratingRangeResult = new
            {
                MinRating = minRatingResult,
                MaxRating = maxRatingResult
            };

            return Ok(new { Products = productsResult, Categories = categoryNamesResult, PriceRange = priceRangeResult, RatingRange = ratingRangeResult });
        }
    }
}
