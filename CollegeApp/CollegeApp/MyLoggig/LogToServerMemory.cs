namespace CollegeApp.MyLoggig
{
    public class LogToServerMemory : IMyLogger
    {
        public void Log(String message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Logto Server Message");
        }
    }
}
