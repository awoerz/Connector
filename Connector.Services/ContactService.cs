using Connector.Data;
using Connector.Models;
using Connector.Models.NoteModels;
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
                MyProperty = model.MyProperty,
                Notes = (ICollection<Note>)Enumerable.Empty<Note>()
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
                var notes = ctx.Notes.Where(e => e.ContactId == id).Select(e => new NoteDetail
                {
                    NoteId = e.NoteId,
                    Content = e.Content,
                    Created = e.Created,
                    Updated = e.Updated,
                    ContactId = (int)e.ContactId
                });

                return new ContactDetail
                {
                    ContactId = entity.ContactId,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber,
                    Notes = notes.ToArray(),
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
                entity.Notes = (ICollection<Note>)model.Notes;
                entity.MyProperty = model.MyProperty;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddNote(int contactId, int noteId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contacts.Single(e => e.ContactId == contactId);
                var note = ctx.Notes.Single(e => e.NoteId == noteId);
                if(entity.Notes != null)
                {
                    entity.Notes.Add(note);
                }
                else
                {
                    entity.Notes = new List<Note>();
                    entity.Notes.Add(note);
                }
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
