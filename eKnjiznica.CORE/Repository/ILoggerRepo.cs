using eKnjiznica.Commons.ViewModels;
using eKnjiznica.CORE.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface ILoggerRepo
    {
        void SaveAdminAction(string adminId, LogType logType, string description);
        List<LogsVM> GetUserLogs();
    }
}
