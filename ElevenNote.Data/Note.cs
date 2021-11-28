using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        [ForeignKey(nameof(Contact))]
        public int? ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        [ForeignKey(nameof(CustomerAccount))]
        public int? CustomerAccountId { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }

    }
}
