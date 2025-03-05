using System;
using System.Diagnostics;

namespace NZWalks.API.Demo
{
    public class GenericsDelegatesDemo : IMyService
    {
        public delegate int Comparison<T>(T x, T y);

        private readonly int _serviceId;
        public void ExecuteDemo()
        {
            DemoPerson[] people =
            {
                new DemoPerson {Name="Alice", Age=30}
                ,new DemoPerson {Name="Bob", Age=25}
                ,new DemoPerson {Name="Charlie", Age=35}
            };

            Debug.WriteLine("Sorting by Age");
            PersonSorter.Sort(people, CompareByAge);
            foreach(var person in people)
            {
                Debug.WriteLine($"{person.Name} : {person.Age}");
            }

            Debug.WriteLine("");

            Debug.WriteLine("Sorting by Name");
            PersonSorter.Sort(people, CompareByName);
            foreach (var person in people)
            {
                Debug.WriteLine($"{person.Name} : {person.Age}");
            }

        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }

        static int CompareByAge(DemoPerson x, DemoPerson y)
        {
            return x.Age.CompareTo(y.Age);
        }

        static int CompareByName(DemoPerson x, DemoPerson y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public class DemoPerson
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class PersonSorter
    {
        public static void Sort(DemoPerson[] people, Comparison<DemoPerson> comparison)
        {
            for(int i=0; i < people.Length-1; i++)
            {
                for(int j=i+1; j < people.Length; j++)
                {
                    if (comparison(people[i], people[j]) > 0)
                    {
                        DemoPerson temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }
            }
        }
    }
}
