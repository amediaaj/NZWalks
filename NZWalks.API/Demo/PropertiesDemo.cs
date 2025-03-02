using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace NZWalks.API.Demo
{
    public class PropertiesDemo : IMyService
    {
        private readonly int _serviceId;
        public PropertiesDemo()
        {
            _serviceId = new Random().Next(100000, 999999);
        }

        public void ExecuteDemo()
        {
            Car myCar = new Car("Mustang", "Ford");
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }
    }

    public class Car
    {
        private string _model = "";
        private string _brand = "";

        public string Model { get => _model; set => _model = value; }
        public string Brand { get { return _brand; } set { _brand = value; } }

        public Car(string model, string brand)
        {
            Model = model;
            Brand = brand;

            Debug.WriteLine($"A {Brand} of the model {model} has been created");
        }
    }
}
