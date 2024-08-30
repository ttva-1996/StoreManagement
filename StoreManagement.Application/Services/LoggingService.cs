namespace StoreManagement.Application.Services
{
    public class LoggingService
    {
        // Private static variable to hold the single instance
        private static readonly Lazy<LoggingService> _instance =
            new Lazy<LoggingService>(() => new LoggingService());

        // Private constructor to prevent instantiation from outside
        private LoggingService()
        {
            // Initialize resources, if any
        }

        // Public static method to get the single instance
        public static LoggingService Instance => _instance.Value;

        // Example logging method
        public void Log(string message)
        {
            // Logic to log messages
            Console.WriteLine($"Log: {message}");
        }
    }

}
