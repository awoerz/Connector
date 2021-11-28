using Connector.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.CustomerAccountModels
{
    public class CustomerAccountListItem
    {
        public int CustomerAccountId { get; set; }
        [Display(Name = "Customer Account Name")]
        public string Name { get; set; }
        public IEnumerable<ContactDetail> Contacts { get; set; }
        public IEnumerable<NoteDetail> Notes { get; set; }
    }
}
