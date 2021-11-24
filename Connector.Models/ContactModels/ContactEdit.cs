using ElevenNote.Data;
using System;
using System.Collections.Generic;
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
        public List<int> NoteIds { get; set; }
        public DateTimeOffset LastContacted { get; set; }
        public ContactMethod MyProperty { get; set; }
    }
}
