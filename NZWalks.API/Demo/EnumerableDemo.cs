using System.Diagnostics;

namespace NZWalks.API.Demo
{ 
    public class EnumerableDemo : IMyService
    {
        private readonly int _serviceId;

        // Ienumerables are a basic interface that allow us to iterate (i.e. ask for
        // one element at a time) from a collection or data source. All collection
        // types in C# inherit from this interface.
        private readonly int[] _myArray;
        public EnumerableDemo()
        {
            _serviceId = new Random().Next(100000, 999999);
            _myArray = new int[] { 1, 2, 3, 4, 5 };
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"{message} - Service ID: {_serviceId}");
        }

        public void ExecuteDemo()
        {
            // we can assign the array to an IEnumerable because it implements the interface
            IEnumerable<int> myArrayAsEnumerable = _myArray as IEnumerable<int>;

            // we can use foreach
            Debug.WriteLine("Using foreach on the array");
            foreach (var item in _myArray)
            {
                Debug.WriteLine(item);
            }

            // Shows that myArrayAsEnumerable is a reference to _myArray
            // myArrayAsEnumerable is a different variable type but references the same collection
            _myArray[0] = 99;

            // we can use foreach
            Debug.WriteLine("Using foreach on the enumerable");
            foreach (var item in myArrayAsEnumerable)
            {
                Debug.WriteLine(item);
            }

            // we cannot use for loops with indexing on IEnumerables! indexing is not
            // supported by IEnumerable, but it does work for arrays
            Debug.WriteLine("Using for loop on the array...");
            for (int i = 0; i < _myArray.Length; i++) 
            { 
                // works!
                Debug.WriteLine(_myArray[i]);
            }

            // we can't even get the length of the enumerable!
            //for (int i = 0; myArrayAsEnumerable.Length; i++) 
            //{
            //    // does not work!
            //    Console.WriteLine(myArrayAsEnumerable[i]);
            //}


            Debug.WriteLine($"Calling iterator that sleeps for 1 second i.e. lazy: {DateTime.Now}");
            var result = SimpleIterator();
            Debug.WriteLine($"Finished iterator that sleeps for 1 second1 i.e. lazy: {DateTime.Now}");

            Debug.WriteLine($"Iterating over iterator that sleeps for 1 seconds i.e. lazy: {DateTime.Now}");
            // Now Thread.Sleep gets executed
            var result_list = result.ToList();
            foreach (var item in result_list)
            {
                Debug.WriteLine($"{item}");
            }
            Debug.WriteLine($"Finished iterating over iterator that sleeps for 1 seconds i.e. lazy: {DateTime.Now}");
        }

        public IEnumerable<int> SimpleIterator()
        {
            foreach (var item in _myArray)
            {
                // Deferred execution
                Thread.Sleep(1000);
                yield return item;
            }
        }
    }
}
