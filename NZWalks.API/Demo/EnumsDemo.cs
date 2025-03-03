using System.Diagnostics;

namespace NZWalks.API.Demo
{
    public class EnumsDemo : IMyService
    {
        private readonly int _serviceId;

        public void ExecuteDemo()
        {
            Day fr = Day.Fr;
            Debug.WriteLine($"Enum Day.Fr: {fr}");
            Debug.WriteLine($"Enum Day.Fr as int: {(int)fr}");
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }
    }
}
