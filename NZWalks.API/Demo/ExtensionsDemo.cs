using System.Diagnostics;

namespace NZWalks.API.Demo
{
    public class ExtensionsDemo : IMyService
    {
        private readonly int _serviceId;
        public void ExecuteDemo()
        {
            string name = "alex";
            string capitalized = name.Capitalize();
            Debug.WriteLine(capitalized + '\n');

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var average = numbers.Average();
            Debug.WriteLine("Average of numbers: {0}", average);

            int[] ints = new[] { 1, 2, 3 };
            average = ints.Average();
            Debug.WriteLine("Average of ints: {0}", average);
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }
    }

    // 1. Declare public static class.
    public static class StringExtensions
    {
        // 2. Declare public static method with this keyword.
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }

    // 1. Declare public static class.
    public static class IEnumerableExtensions
    {
        // 2. Declare public static method with this keyword.
        public static double Average(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return (double)source.Sum() / source.Count();
        }
    }
}
