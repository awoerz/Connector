using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
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
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public int PhoneNumber { get; set; }
        [Display(Name = "Notes")]
        public List<int> NoteIds { get; set; }
        [Display(Name = "Date Contact Created")]
        public DateTime Created { get; set; }
        [Display(Name = "Date Last Contacted")]
        public DateTime LastContacted { get; set; }
        [Display(Name = "Primary Contact Method")]
        public ContactMethod MyProperty { get; set; }
    }
}
