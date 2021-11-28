using Connector.Data;
using Connector.Models;
using Connector.Models.CustomerAccountModels;
using Connector.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Services
{
    public class CustomerAccountService
    {
        private readonly Guid _userId;
        public CustomerAccountService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomerAccount(CustomerAccountCreate model)
        {
            var entity = new CustomerAccount()
            {
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomerAccounts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerAccountListItem> GetCustomerAccounts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .CustomerAccounts
                    .Select(e => new CustomerAccountListItem
                    {
                        CustomerAccountId = e.CustomerAccountId,
                        Name = e.Name
                    });

                return query.ToArray();
            }
        }
        public CustomerAccountDetail GetCustomerAccountById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CustomerAccounts.Single(
                        e => e.CustomerAccountId == id
                    );
                var notes = ctx.Notes.Where(e => e.CustomerAccountId == id).Select(e => new NoteDetail
                {
                    NoteId = e.NoteId,
                    Content = e.Content,
                    Created = e.Created,
                    Updated = e.Updated,
                    CustomerAccountId = (int)e.CustomerAccountId
                });
                var contacts = ctx.Contacts.Where(e => e.CustomerAccountId == id).Select(e => new ContactDetail
                {
                    ContactId = e.ContactId,
                    Name = e.Name,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    Created = e.Created,
                    LastContacted = e.LastContacted,
                    MyProperty = e.MyProperty
                });

                return new CustomerAccountDetail
                {
                    CustomerAccountId = entity.CustomerAccountId,
                    Name = entity.Name,
                    Notes = notes.ToArray(),
                    Contacts = contacts.ToArray()
                };
            }
        }
        public bool UpdateCustomerAccount(CustomerAccountEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CustomerAccounts.Single(
                    e => e.CustomerAccountId == model.CustomerAccountId
                );

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool AddNote(int customerAccountId, int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customerAccount = ctx.CustomerAccounts.Single(e => e.CustomerAccountId == customerAccountId);
                var note = ctx.Notes.Single(e => e.NoteId == noteId);
                if(customerAccount.Notes != null)
                {
                    customerAccount.Notes.Add(note);
                }
                else
                {
                    customerAccount.Notes = new List<Note>();
                    customerAccount.Notes.Add(note);
                }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool AddContact(int customerAccountId, int contactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customerAccount = ctx.CustomerAccounts.Single(e => e.CustomerAccountId == customerAccountId);
                var contact = ctx.Contacts.Single(e => e.ContactId == contactId);
                if (customerAccount.Notes != null)
                {
                    customerAccount.Contacts.Add(contact);
                }
                else
                {
                    customerAccount.Contacts = new List<Contact>();
                    customerAccount.Contacts.Add(contact);
                }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomerAccount(int customerAccountId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CustomerAccounts.Single(
                    e => e.CustomerAccountId == customerAccountId
                );

                ctx.CustomerAccounts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
