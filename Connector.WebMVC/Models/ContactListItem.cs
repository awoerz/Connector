using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Connector.WebMVC.Models
{
    public class ContactListItem
    {
        [Display(Name = "Contact Name")]
        public string Name { get; set; }
        [Display(Name = "Contact Email")]
        public string Email { get; set; }
        [Display(Name = "Contact Phone Number")]
        public int PhoneNumber { get; set; }
        public DateTime Created { get; set; }
        [Display(Name = "Date Last Contacted")]
        public DateTime LastContacted { get; set; }
        [Display(Name = "Primary Contact Method")]
        public ContactMethod MyProperty { get; set; }
    }
}