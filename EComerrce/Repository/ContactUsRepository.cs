using EComerrce.Data;
using EComerrce.IRepository;
using EComerrce.Models;

namespace EComerrce.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        ApplicationDbContext context;

        public ContactUsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ContactUs> GetAll()
        {
            return context.ContactUses.ToList();
        }

        public ContactUs GetById(int id)
        {
            return context.ContactUses.FirstOrDefault(c => c.Id == id);
        }

        public void Create(ContactUs contact)
        {
            context.ContactUses.Add(contact);
            context.SaveChanges();
        }

        public void Update(ContactUs contact)
        {
            context.ContactUses.Update(contact);
            context.SaveChanges();
        }

        public ContactUs Delete(int id)
        {
            var contact = context.ContactUses.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                context.ContactUses.Remove(contact);
                context.SaveChanges();
            }
            return contact;
        }
    }
}
