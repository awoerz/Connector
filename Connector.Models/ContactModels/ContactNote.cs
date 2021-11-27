using Connector.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.ContactModels
{
    public class ContactNote
    {
        public int ContactId { get; set; }
        public string NoteContent { get; set; }
    }
}
