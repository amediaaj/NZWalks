using System.Diagnostics;

namespace NZWalks.API.Demo
{
    public class DelegatesDemo : IMyService
    {
        private readonly int _serviceId;

        // Delegates define a method signature,
        // and any method assigned to a delegate must match this signature.

        // 1. Declaration:
        public delegate void Notify(string message);

        public void ExecuteDemo()
        {
            // 2. Instantiation:
            Notify notifyDelegate = ShowMessage;

            // Old way
            // Notify notifyDelegate = new Notify(ShowMessage);

            // 3. Invocation:
            notifyDelegate("Hello World!");
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }

        static void ShowMessage(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
