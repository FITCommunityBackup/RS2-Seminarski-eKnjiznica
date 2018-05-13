using eKnjiznica.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Logger
{
    public class LoggerService : ILoggerService
    {
        private ILoggerRepo loggerRepo;

        public LoggerService(ILoggerRepo loggerRepo)
        {
            this.loggerRepo = loggerRepo;
        }

        public void LogAdminAction(string adminId, LogType logType, string description)
        {
            loggerRepo.SaveAdminAction(adminId, logType, description, DateTime.UtcNow);
        }
    }
}
