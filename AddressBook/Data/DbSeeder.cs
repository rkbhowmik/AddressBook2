using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.Data
{
    public static class DbSeeder
    {
        public static void Initialize(AddressBookContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any person
            if (context.Person.Any())
            {
                return;
            }

            var michaelJackson = new Person { FirstName = "Michael", LastName = "Jackson" };

            var person = new Person[]
            {
                michaelJackson,
                new Person {FirstName = "Steve", LastName = "Jobs"},
                new Person {FirstName = "Bill", LastName = "Gates"},
                new Person {FirstName = "Rajib Kumar", LastName = "Bhowmik"},
                new Person {FirstName = "Steve", LastName = "Ozniyak"},
            };

            foreach (Person p in person)
            {
                context.Person.Add(p);
            }
            context.SaveChanges();

            var address = new Address[]
            {
                new Address
                {
                    Person = michaelJackson,
                    StreetName = "Kungsgatan",
                    HomeNumber = "1A",
                    PostalCode = "12345",
                    City = "Stockolm",
                    PhoneNumber = "0712345678",
                    Email = "micjack@yahoo.com",
                   
                },
                new Address
                {
                    Person = michaelJackson,
                    StreetName = "Häggviksdalen",
                    HomeNumber = "12",
                    PostalCode = "14589",
                    City = "Stockolm",
                    PhoneNumber = "0712545678",
                    Email = "stevejobs@apple.com",
                 
                },
                new Address
                {
                    Person = michaelJackson,
                    StreetName = "Visättravägen",
                    HomeNumber = "32",
                    PostalCode = "14859",
                    City = "Flemingsberg",
                    PhoneNumber = "0712007678",
                    Email = "billgates@outlook.com",
              
                },
                new Address
                {
                    Person = michaelJackson,
                    StreetName = "Bandstolsvägen",
                    HomeNumber = "49",
                    PostalCode = "75648",
                    City = "Uppsala",
                    PhoneNumber = "0712995678",
                    Email = "rajll828@yahoo.com",
                 
                },
                new Address
                {
                    Person = michaelJackson,
                    StreetName = "Kistadalen",
                    HomeNumber = "12B",
                    PostalCode = "19765",
                    City = "Stockolm",
                    PhoneNumber = "0713987600",
                    Email = "ozniyak@gmail.com"
                }
            };
            foreach (Address a in address)
            {
                context.Address.Add(a);
            }
            context.SaveChanges();
        }
    }
}
