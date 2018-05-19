using eKnjiznica.Commons.ViewModels;
using eKnjiznica.CORE.Repository;
using eKnjiznica.CORE.Services.Logger;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class LoggerRepo : ILoggerRepo
    {
        EF.EKnjiznicaDB context;

        public LoggerRepo(EKnjiznicaDB context)
        {
            this.context = context;
        }

        public List<LogsVM> GetUserLogs()
        {
            return context.UserAudits
                .Include(x=>x.ApplicationUser)
                 .Select(x => new LogsVM
                 {
                     AdminId = x.UserId,
                     AdminUsername = x.ApplicationUser.UserName,
                     ActionDescription = x.Description,
                     ActionType = x.ActionName,
                     Date = x.Date
                 }).ToList();
        }

        public void SaveAdminAction(string adminId, LogType logType, string description)
        {
            string actionName;
            switch (logType)
            {
                case LogType.CREATE:
                    actionName = "CREATE";
                    break;
                case LogType.UPDATE:
                    actionName = "UPDATE";
                    break;
                case LogType.DELETE:
                    actionName = "DELETE";
                    break;
                default:
                    throw new InvalidOperationException("Log type not valid");
            }

            context.UserAudits.Add(new Model.UserAudit
            {
                ActionName = actionName,
                UserId = adminId,
                Date = DateTime.UtcNow,
                Description = description
            });
            context.SaveChanges();
        }
    }
}
