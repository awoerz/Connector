using Connector.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.CustomerAccountModels
{
    public class CustomerAccountEdit
    {
        public int CustomerAccountId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ContactDetail> Contacts { get; set; }
        public IEnumerable<NoteDetail> Notes { get; set; }
    }
}
