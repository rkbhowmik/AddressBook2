using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Address
    {
        public int AddressID { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public string HomeNumber { get; set; }

        public int PostalCode { get; set; }
        public string City { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
