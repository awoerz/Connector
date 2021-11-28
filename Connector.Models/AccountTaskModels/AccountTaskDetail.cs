using Connector.Data;
using Connector.Models.CustomerAccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.AccountTaskModels
{
    public class AccountTaskDetail
    {
        public int TaskId { get; set; }
        [Display(Name = "Task Description")]
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool Completed { get; set; }
        [Display(Name = "Releated Customer Account")]
        public int CustomerAccountId { get; set; }
        public CustomerAccountDetail CustomerAccount { get; set; }
    }
}
