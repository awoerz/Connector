using Connector.Data;
using Connector.Models;
using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Services
{
    public class ContactService
    {
        private readonly Guid _userId;

        public ContactService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContact(ContactCreate model)
        {
            var entity = new Contact()
            {
                Name = model.Name,
                OwnerId = _userId,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Created = DateTime.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ContactListItem> GetContacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Contacts
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new ContactListItem
                    {
                        Name = e.Name,
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber,
                        Created = e.Created
                    });
                return query.ToArray();
            }
        }
    }
}
