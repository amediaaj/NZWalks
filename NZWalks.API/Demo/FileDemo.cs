using System.Diagnostics;

namespace NZWalks.API.Demo
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            // @ verbatim string literal
            string directoryPath = @".\Logs";
            string filePath = System.IO.Path.Combine(directoryPath, "FileDemo.txt");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.AppendAllText(filePath, message);
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine($"Logging to database: {message}");
            // Implement logic to log a message to the database.
        }
    }

    public class Application
    {
        private readonly ILogger _logger;
        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Work Started.\n");
            // Do all the work.
            _logger.Log("Work Finished.\n");
        }
    }

    public class FileDemo : IMyService
    {
        private readonly int _serviceId;
        private readonly ILogger _logger;

        public FileDemo(ILogger logger)
        {
            _serviceId = new Random().Next(100000, 999999);
            _logger = logger;
        }
        public void ExecuteDemo()
        {
            Application app = new Application(_logger);
            app.DoWork();
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }
    }
}
