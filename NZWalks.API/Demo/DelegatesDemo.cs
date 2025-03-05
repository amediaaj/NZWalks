using System.Diagnostics;

namespace NZWalks.API.Demo
{
    // 1. Declaration:
    public delegate void Notify(string message);

    public class DelegatesDemo : IMyService
    {
        private readonly int _serviceId;

        // Delegates define a method signature,
        // and any method assigned to a delegate must match this signature.

        public void ExecuteDemo()
        {
            // 2. Instantiation:
            Notify notifyDelegate = ShowMessage;

            // Old way
            // Notify notifyDelegate = new Notify(ShowMessage);

            // 3. Invocation:
            notifyDelegate("Hello World!");


            DelegateLogger logger = new DelegateLogger(LogToConsole);
            // Increment multicast of delegate Notify
            logger.AddLogger(LogToFile);

            // Call both instances of delegate Notify
            logger.Log("Logging...");
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }

        static void ShowMessage(string message)
        {
            Debug.WriteLine(message);
        }

        static void LogToConsole(string message)
        {
            Debug.WriteLine("Console: " + message);
        }

        static void LogToFile(string message)
        {
            Debug.WriteLine("File: " + message);
        }
    }

    public class DelegateLogger
    {
        public Notify _log;
        public DelegateLogger(Notify log)
        {
            _log = log;
        }

        public void AddLogger(Notify log)
        {
            // Setup multicast of Notify delegate
            _log += log;
        }

        public void Log(string message)
        {
            _log(message);
        }
    }
}
