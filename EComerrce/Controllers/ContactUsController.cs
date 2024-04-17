using EComerrce.DTO;
using EComerrce.IRepository;
using EComerrce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerrce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
       
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _contactUsRepository.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _contactUsRepository.GetById(id);
            if (contact != null)
            {
                return Ok(contact);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                _contactUsRepository.Create(contact);
                return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ContactUsDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                var Contact = _contactUsRepository.GetById(id);
                if (Contact == null)
                {
                    return NotFound();
                }

                Contact.Name = contactDTO.Name;
                Contact.Email = contactDTO.Email;
               Contact.Message = contactDTO.Message;
                Contact.Subject = contactDTO.Subject;
                Contact.Status = contactDTO.Status;

                _contactUsRepository.Update(Contact);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedContact = _contactUsRepository.Delete(id);
            if (deletedContact == null)
            {
                return NotFound();
            }
            return Ok(deletedContact);
        }
    }
}
