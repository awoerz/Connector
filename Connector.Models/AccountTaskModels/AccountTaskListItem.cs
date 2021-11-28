using Connector.Data;
using Connector.Models.CustomerAccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.AccountTaskModels
{
    public class AccountTaskListItem
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool Completed { get; set; }
        public int CustomerAccountId { get; set; }
        public CustomerAccountDetail CustomerAccount { get; set; }
    }
}
