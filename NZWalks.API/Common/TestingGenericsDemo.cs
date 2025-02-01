using System.Diagnostics;
using System.Drawing;
using Pastel;

namespace NZWalks.API.Common
{
    public class TestingGenericsDemo : IMyService
    {
        private readonly int _serviceId;
        private void Start()
        {
            int[] intArray = CreateArray<int>(9, 6);
            Debug.WriteLine(intArray.Length + " " + intArray[0] + " " + intArray[1]);

            string[] stringArray = CreateArray<string>("hello", "goodbye");
            Debug.WriteLine(stringArray.Length + " " + stringArray[0] + " " + stringArray[1]);


        }

        private T[] CreateArray<T>(T firstElement, T secondElement)
        {
            return new T[] { firstElement, secondElement};
        }

        private void TestMultiGenerics<T1, T2>(T1 t1, T2 t2)
        {
            Debug.WriteLine(t1.GetType());
            Debug.WriteLine(t2.GetType());
        }


        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }

        public void ExecuteDemo()
        {
            Start();
            TestMultiGenerics<int, string>(5, "Hello World!");
        }
    }
}
