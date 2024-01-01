using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{

    /*
     * - Used as an abstraction layer between high level and low level class
     * - Implmenting Inversion Control Principle
     */
    internal interface IEmailService
    {
        void SendEmail(string to, string message);
    }
}
