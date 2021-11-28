using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.NoteModels
{
    public class NoteDetail
    {
        public int NoteId { get; set; }
        public string Content { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Date Edited")]
        public DateTimeOffset? Updated { get; set; }
        public int ContactId { get; set; }
        public int CustomerAccountId { get; set; }
    }
}
