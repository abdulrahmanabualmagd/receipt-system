namespace Async_Await
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Start Main Method");
            
            // The control will not be blocked with the 'DoAsyncWork' method it will return to main until the Task is completed
            // await keyword must be inside an async method
            // We use await with the tasks that could take too long time to load so we use it to avoid blocking the control and be responsive with other acitons
            await DoAsyncWork();

            Console.WriteLine("End Main Method");
        }

        static async Task DoAsyncWork()
        {
            Console.WriteLine("Start Asynch Work...");


            // Because of using await, the contorl will not be blocked, instead it will return to the main method 
            await Task.Delay(2000);

            Console.WriteLine("End of Async Work...");
        }
    }
}