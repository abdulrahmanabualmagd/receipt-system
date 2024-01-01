namespace Dependency_Injection
{
    class Program
    {
        static void Main()
        {

            EmailService emailservice = new EmailService();

            UserService userservice = new UserService(emailservice);

            userservice.RegisterUser("Abdulrahman", "abdo@gmail.com");

        }
    }
}