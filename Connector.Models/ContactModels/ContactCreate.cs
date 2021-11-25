using Connector.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models
{
    public class ContactCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Primary Contact Method")]
        public ContactMethod MyProperty { get; set; }

    }
}
