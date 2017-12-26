using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Person
    {
        public int PersonID { get; set; }    
        
        [Required(ErrorMessage = "Please write your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please write your last name")]
        public string LastName { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}
