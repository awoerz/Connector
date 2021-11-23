﻿using ElevenNote.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Connector.Models
{
    public class ContactListItem
    {
        [Display(Name = "Contact Name")]
        public string Name { get; set; }
        [Display(Name = "Contact Email")]
        public string Email { get; set; }
        [Display(Name = "Contact Phone Number")]
        public string PhoneNumber { get; set; }
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Date Last Contacted")]
        public DateTimeOffset LastContacted { get; set; }
        [Display(Name = "Primary Contact Method")]
        public ContactMethod MyProperty { get; set; }
    }
}