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

        [RegularExpression(@"\+?(?:0{0,2}[46]*){1}7{1}[0-9]{8}", ErrorMessage = "Typing format: +46xxxxxxxxx")]
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
       
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string StreetName { get; set; }
        [Required]
        [Display(Name = "House No.")]
        public string HomeNumber { get; set; }
        [Required]
        [Display(Name = "Post Code")]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }

        
        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
