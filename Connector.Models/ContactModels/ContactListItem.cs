using Connector.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Connector.Models
{
    public class ContactListItem
    {
        public int ContactId { get; set; }
        [Display(Name = "Contact Name")]
        public string Name { get; set; }
        [Display(Name = "Contact Email")]
        public string Email { get; set; }
        [Display(Name = "Contact Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Date Last Contacted")]
        public DateTimeOffset? LastContacted { get; set; }
        [Display(Name = "Primary Contact Method")]
        public ContactMethod MyProperty { get; set; }
        public IEnumerable<Note> Notes { get; set; }    
    }
}