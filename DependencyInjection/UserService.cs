using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    /*
     * - High Level module use injected with Service (IEmailService) which is an abstraction layer 
     *   between high level module (UserService) and low level module (EmailService)
     * - The purpose of using abstraction layer is to implement Inversion Control Principle
     */
    internal class UserService
    {
        /*
         * - Instead of Creating the whole object here we Inject it using Constructor Injection
         * - So If I modified the low level class, I won't to have to modify the higher class and that's because the injecion
         */
        #region Dependency Injection
        private IEmailService _emailService;

        // Injecting the abstraction Layer (Emailservice) the medium between high and low level modules
        public UserService(IEmailService emailService)
        {
            this._emailService = emailService;
        }
        #endregion


        #region Use Low level module method
        public void RegisterUser(string username, string email)
        {
            _emailService.SendEmail(username, "Welcome!");
        } 
        #endregion
    }
}
