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

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Please write your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Please write your last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}
