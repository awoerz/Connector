using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models.NoteModels
{
    public class NoteCreate
    {
        public int NoteId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public int? ContactId { get; set; }
    }
}
