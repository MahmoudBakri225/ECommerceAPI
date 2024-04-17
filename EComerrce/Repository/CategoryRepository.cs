using EComerrce.Data;
using EComerrce.IRepository;
using EComerrce.Models;
using Microsoft.EntityFrameworkCore;

namespace EComerrce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public Category Delete(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return category;
        }
       
    }
}
