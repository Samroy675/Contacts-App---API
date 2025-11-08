using contacts_app.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace contacts_app
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {


        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
