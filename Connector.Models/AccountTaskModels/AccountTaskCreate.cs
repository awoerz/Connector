using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.AccountTaskModels
{
    public class AccountTaskCreate
    {
        public int TaskId { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        [Required]
        public bool Completed { get; set; }
        public int CustomerAccountId { get; set; }
    }
}
