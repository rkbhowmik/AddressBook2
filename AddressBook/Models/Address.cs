using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
       
        public string Email { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string HomeNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
