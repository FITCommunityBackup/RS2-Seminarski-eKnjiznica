using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.EmailService
{
    public interface IEmailService
    {
        Task SendBooks(List<string> bookLocations,string to);
    }
}
