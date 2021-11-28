using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.CustomerAccountModels
{
    public class CustomerAccountCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
