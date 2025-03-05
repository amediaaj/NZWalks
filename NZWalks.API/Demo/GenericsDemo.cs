using System.Diagnostics;

namespace NZWalks.API.Demo
{
    public class GenericsDemo : IMyService
    {
        private readonly int _serviceId;
        public void ExecuteDemo()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] strings = { "abc", "def", "ghi" };

            PrintArray<int>(nums);
            Debug.WriteLine("");
            PrintArray<string>(strings);
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }

        public static void PrintIntArray(int[] array)
        {
            foreach(int item in array)
            {
                Debug.WriteLine(item);
            }
        }

        public static void PrintStringArray(string[] array)
        {
            foreach(string item in array)
            {
                Debug.WriteLine(item);
            }
        }

        public static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
            {
                Debug.WriteLine(item);
            }
        }
    }
}
