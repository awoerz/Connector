using Connector.Data;
using Connector.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userid)
        {
            _userId = userid;
        }

        public bool CreateNote(NoteCreate model)
        {
            var entity = new Note()
            {
                Content = model.Content,
                Created = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateNoteForContact(int contactId,NoteCreate model)
        {
            var entity = new Note()
            {
                Content = model.Content,
                Created = DateTimeOffset.Now,
                ContactId = contactId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateNoteForCustomerAccount(int customerAccountId, NoteCreate model)
        {
            var entity = new Note()
            {
                Content = model.Content,
                Created = DateTimeOffset.Now,
                CustomerAccountId = customerAccountId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public int CreateNoteReturnId(NoteCreate model)
        {
            var entity = new Note()
            {
                Content = model.Content,
                Created = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                ctx.SaveChanges();

                return entity.NoteId;
            }
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Notes.Select(e => new NoteListItem
                    {
                        NoteId = e.NoteId,
                        Content = e.Content,
                        Created = e.Created,
                        Updated = e.Updated
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<NoteListItem> GetNotesFromList(List<int> noteIds)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query = ctx.Notes.Where(e => noteIds.Contains(e.NoteId)).Select(e =>
                    new NoteListItem
                    {
                        NoteId = e.NoteId,
                        Content = e.Content,
                        Created = e.Created,
                        Updated = e.Updated
                    }

                );

                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Notes.Single(e => e.NoteId == id);

                return new NoteDetail
                {
                    NoteId = entity.NoteId,
                    Content = entity.Content,
                    Created = entity.Created,
                    Updated = entity.Created
                };
            }
        }
        
        public bool UpdateNote(NoteEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Notes.Single(e => e.NoteId == model.NoteId);

                entity.Content = model.Content;
                entity.Created = model.Created;
                entity.Updated = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Notes.Single(e => e.NoteId == noteId);

                ctx.Notes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
