using contacts_app.Models;
using Microsoft.EntityFrameworkCore;

namespace contacts_app.Interface
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetAllContactByIdAsync(int id);
        Task<Contact> InsertContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task DeleteContact(int id);

    }

    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext context;
        public ContactRepository(ContactDbContext _context)
        {
            this.context = _context;
        }
        public async Task DeleteContact(int id)
        {
            var cts = await context.Contacts.FindAsync(id);
            if(cts != null)
            {
                context.Remove(cts);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Contact> GetAllContactByIdAsync(int id) => await context.Contacts.FindAsync(id);

        public async Task<IEnumerable<Contact>> GetAllContactsAsync() => await context.Contacts.ToListAsync();

        public async Task<Contact> InsertContact(Contact contact)
        {
            context.Contacts.Add(contact);
            await context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            try
            {
                var cts = await context.Contacts.FindAsync(contact.contactId);
                if (cts != null)
                {
                    cts.contactName = contact.contactName;
                    cts.contactPhoneNo = contact.contactPhoneNo;
                    cts.contactPhoto = contact.contactPhoto;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return contact;
        }
    }
}
