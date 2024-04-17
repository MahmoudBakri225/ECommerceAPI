using EComerrce.Models;

namespace EComerrce.IRepository
{
    public interface IContactUsRepository
    {

        IEnumerable<ContactUs> GetAll();
        ContactUs GetById(int id);
        void Create(ContactUs contact);
        void Update(ContactUs contact);
        ContactUs Delete(int id);
    }
}
