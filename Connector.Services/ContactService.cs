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
                Created = DateTime.Now,
                MyProperty = model.MyProperty
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
                        ContactId = e.ContactId,
                        Name = e.Name,
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber,
                        Created = e.Created,
                        MyProperty = e.MyProperty
                    });
                return query.ToArray();
            }
        }
    
        public ContactDetail GetContactById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contacts.Single(
                        e => e.ContactId == id && e.OwnerId == _userId
                     );

                return new ContactDetail
                {
                    ContactId = entity.ContactId,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber,
                    NoteIds = entity.NoteIds,
                    Created = entity.Created,
                    LastContacted = entity.LastContacted,
                    MyProperty = entity.MyProperty
                };
            }
        }

        public bool UpdateContact(ContactEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contacts.Single(
                        e => e.ContactId == model.ContactId && e.OwnerId == _userId
                    );

                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.NoteIds = model.NoteIds;
                entity.MyProperty = model.MyProperty;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContact(int contactId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contacts.Single(
                        e => e.ContactId == contactId && e.OwnerId == _userId
                    );

                ctx.Contacts.Remove(entity);
                return ctx.SaveChanges() == 1;
            };
        }
    }
}
