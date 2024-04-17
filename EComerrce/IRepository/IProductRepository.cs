using EComerrce.Models;

namespace EComerrce.IRepository
{
    public interface IProductRepository
    {
        void Create(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        Product Update(Product product);
        bool Delete(int id);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        public IEnumerable<Product> FilterProducts(string[] brands, decimal minPrice, decimal maxPrice, int rating);
    }
}
