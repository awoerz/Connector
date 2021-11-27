using Connector.Data;
using Connector.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models
{
    public class ContactDetail
    {
        public int ContactId { get; set; }
        [Display(Name = "Contact Name")]
        public string Name { get; set; }
        [Display(Name = "Contact Email")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public IEnumerable<NoteDetail> Notes { get; set; }
        [Display(Name = "Contact Created")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Last Time Contacted ")]
        public DateTimeOffset? LastContacted { get; set; }
        [Display(Name = "Primary Contact Method")]
        public ContactMethod MyProperty { get; set; }
    }
}
