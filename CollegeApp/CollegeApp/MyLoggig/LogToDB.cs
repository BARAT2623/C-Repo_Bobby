namespace CollegeApp.MyLoggig
{
    public class LogToDB : IMyLogger
    {
        public void Log(String message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogtoDB");
        }
    }
}
