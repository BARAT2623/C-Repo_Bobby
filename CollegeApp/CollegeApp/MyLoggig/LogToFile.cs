namespace CollegeApp.MyLoggig
{
    public class LogToFile : IMyLogger
    {
        public void Log(String message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogtoFile");
        }
    }
}
