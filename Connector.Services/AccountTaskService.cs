using Connector.Data;
using Connector.Models.AccountTaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Services
{
    public class AccountTaskService
    {
        public readonly Guid _userId;
        public AccountTaskService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAccountTask(AccountTaskCreate model)
        {
            var entity = new AccountTask()
            {
                Description = model.Description,
                Created = DateTimeOffset.Now,
                CustomerAccountId = model.CustomerAccountId,
                Completed = false,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AccountTasks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AccountTaskListItem> GetAccountTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .AccountTasks
                    .Select(e => new AccountTaskListItem
                    {
                        TaskId = e.TaskId,
                        Description = e.Description,
                        Created = e.Created,
                        Completed = e.Completed,
                        CustomerAccountId = e.CustomerAccountId,
                    });
                return query.ToArray();
            }
        }
        public AccountTaskDetail GetAccountTaskById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.AccountTasks.Single(
                        e => e.TaskId == id 
                     );
                return new AccountTaskDetail
                {
                    TaskId = entity.TaskId,
                    Description = entity.Description,
                    Created = entity.Created,
                    Completed = entity.Completed,
                    CustomerAccountId = entity.CustomerAccountId,
                };
            }
        }
        public bool UpdateAccountTask(AccountTaskEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.AccountTasks.Single(e => e.TaskId == model.TaskId);

                entity.TaskId = model.TaskId;
                entity.Description = model.Description;
                entity.Completed = model.Completed;
                entity.CustomerAccountId = model.CustomerAccountId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool ToggleAccountTaskComplete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var task = ctx.AccountTasks.Single(e => e.TaskId == id);
                if (!task.Completed)
                {
                    task.Completed = true;
                }
                else
                {
                    task.Completed = false;
                };

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteTaskAccount(int accountTaskId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.AccountTasks.Single(
                    e => e.TaskId == accountTaskId
                );

                ctx.AccountTasks.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
