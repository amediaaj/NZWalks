using System.Diagnostics;

namespace NZWalks.API.Common
{
    public class InheritanceDemo : IMyService
    {
        private int _serviceId;

        public InheritanceDemo()
        {
            _serviceId = new Random().Next(100000, 999999);
        }

        public void ExecuteDemo()
        {
            Employee employee = new Employee("Alex", 45, "Manager", 555);
            employee.BecomeOlder(7);
            employee.DisplayPersonInfo();
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }

    }

    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Debug.WriteLine("Person constructor called.");
            Name = name;
            Age = age;
        }

        public virtual void DisplayPersonInfo()
        {
            Debug.WriteLine($"Name: {Name} Age: {Age}");
        }

        /// <summary>
        /// Increments the age of the person by specified years
        /// </summary>
        /// <param name="years">The amount of years to increment</param>
        /// <returns>The new age</returns>
        public int BecomeOlder(int years)
        {
            return Age += years;
        }
    }

    public class Employee : Person
    {
        public string JobTitle { get; private set; }
        public int Id { get; private set; }
        public Employee(string name, int age, string jobTitle, int id) : base(name, age)
        {
            JobTitle = jobTitle;
            Id = id;
            Debug.WriteLine("Employee constructor called.");
        }

        public override void DisplayPersonInfo()
        {
            base.DisplayPersonInfo();
            Debug.WriteLine($"Job Title: {JobTitle} Id: {Id}");
        }
    }
}
