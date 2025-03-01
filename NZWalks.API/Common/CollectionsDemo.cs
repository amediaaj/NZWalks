using System;
using System.Diagnostics;
using System.Drawing;

namespace NZWalks.API.Common
{
    public class CollectionsDemo : IMyService
    {
        private int _serviceId;

        public CollectionsDemo()
        {
            _serviceId = new Random().Next(100000, 999999);
        }

        public void ExecuteDemo()
        {
            List<string> colors = new List<string> { "red", "blue", "green" };
            foreach(string color in colors)
            {
                Debug.WriteLine(color);
            }

            Debug.WriteLine("");
            colors.Remove("red");
            colors.Add("purple");
            colors.Sort();

            foreach (string color in colors)
            {
                Debug.WriteLine(color);
            }

            Debug.WriteLine("");
            List<int> nums = new List<int> { 1, 3, 7, 10, 55, 42, 24, 11, 16 };
            List<int> largeNums = nums.FindAll(x => x >= 10);

            foreach(int num in largeNums)
            {
                Debug.WriteLine(num);
            }

            Debug.WriteLine("");
            // Predicate alternative
            Predicate<int> lessThanEight = x => x <= 7;

            // Can assign a function
            //lessThanEight = assignedToPredicate;
            // Can instantiate predicate
            // lessThanEight = new Predicate<int>(assignedToPredicate);

            List<int> smallNums = nums.FindAll(lessThanEight);

            foreach(int num in smallNums)
            {
                Debug.WriteLine(num);
            }

            Debug.WriteLine("");

            if (largeNums.Any(x => x> 50))
            {
                Debug.WriteLine("There are really big numbers!");
            }

        }

        private bool assignedToPredicate(int x)
        {
            return x <= 7;
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }
    }
}
