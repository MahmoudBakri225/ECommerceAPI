using EComerrce.Data;
using EComerrce.IRepository;
using EComerrce.Models;
using Microsoft.EntityFrameworkCore;

namespace EComerrce.Repository
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return product;
        }


        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return context.Products.Where(p => p.CategoryID == categoryId).ToList();
        }
        public IEnumerable<Product> FilterProducts(string[] brands, decimal minPrice, decimal maxPrice, int rating)
        {
            var query = context.Products.AsQueryable();

            if (brands != null && brands.Length > 0)
            {
                query = query.Where(p => brands.Contains(p.Name)); // استبدل Name بالخاصية الصحيحة
            }

            query = query.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            // استبدل Rating بالخاصية الصحيحة في نموذج Product
            query = query.Where(p => p.Rating == rating);

            return query.ToList();
        }
    }
}
