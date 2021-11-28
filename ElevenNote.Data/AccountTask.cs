using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Data
{
    public class AccountTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        [Required]
        public bool Completed { get; set; }
        [ForeignKey(nameof(CustomerAccount))]
        public int CustomerAccountId { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; } 
    }
}
