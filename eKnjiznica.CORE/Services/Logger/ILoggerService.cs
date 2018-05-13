using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Logger
{
    public interface ILoggerService
    {
        void LogAdminAction(string adminId, LogType logType, string description);

    }
}
