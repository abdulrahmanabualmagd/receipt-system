using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{

    internal class EmailService : IEmailService
    {
        void IEmailService.SendEmail(string to, string message)
        {
            Console.WriteLine($"To: {to}, Message: {message}");
        }
        
    }
}
