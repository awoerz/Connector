using ElevenNote.Data;
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
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Created")]
        public string PhoneNumber { get; set; }
        public List<int> NoteIds { get; set; }
        [Display(Name = "Contact Created")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Last Time Contacted ")]
        public DateTimeOffset LastContacted { get; set; }
        public ContactMethod MyProperty { get; set; }
    }
}
