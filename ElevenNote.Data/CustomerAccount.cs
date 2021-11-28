using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Data
{
    public class CustomerAccount
    {
        [Key]
        public int CustomerAccountId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<AccountTask> Tasks { get; set; }
    }
}