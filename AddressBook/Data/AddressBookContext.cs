using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;

namespace AddressBook.Models
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext (DbContextOptions<AddressBookContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Address> Address { get; set; }
       
    }
}
