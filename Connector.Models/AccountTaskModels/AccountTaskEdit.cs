using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.AccountTaskModels
{
    public class AccountTaskEdit
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int CustomerAccountId { get; set; }
    }
}
