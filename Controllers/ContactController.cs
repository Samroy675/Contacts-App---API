using contacts_app.Interface;
using contacts_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contacts_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContactsAsync()
        {
            var cts = await _contactRepository.GetAllContactsAsync();
            if (cts == null)
            {
                return NotFound();
            }
            return Ok(cts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllContactByIdAsync(int id)
        {
            var cts = await _contactRepository.GetAllContactByIdAsync(id);
            if (cts == null)
            {
                return NotFound();
            }
            return Ok(cts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            var cts = await _contactRepository.GetAllContactByIdAsync(id);
            if (cts == null)
            {
                return NotFound($"Contact record of {id} not found");
            }
            await _contactRepository.DeleteContact(id);    
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertContactAsync([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return NotFound();
            }
            await _contactRepository.InsertContact(contact);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactAsync(int id, [FromBody] Contact contact)
        {
            if (id != contact.contactId)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }
            var cts = await _contactRepository.GetAllContactByIdAsync(id);
            if (cts == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            await _contactRepository.UpdateContact(contact);
            return NoContent();
        }
    }
}
