using EComerrce.Models;

namespace EComerrce.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Create(Category category);
        void Update(Category category);
        Category Delete(int id);
    }
}
