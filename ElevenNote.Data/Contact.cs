using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Data
{
    public enum ContactMethod
    {
        Phone,
        Email
    }

    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastContacted { get; set; }
        public ContactMethod MyProperty { get; set; }
        public ICollection<Note> Notes { get; set; }
        
        [ForeignKey(nameof(CustomerAccount))]
        public int? CustomerAccountId { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}
 