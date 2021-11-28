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
    public class ContactEdit
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<NoteDetail> Notes { get; set; }
        public DateTimeOffset? LastContacted { get; set; }
        [Display(Name = "Primary Contact Method")]
        public ContactMethod MyProperty { get; set; }
        public int CustomerAccountId { get; set; }
    }
}
