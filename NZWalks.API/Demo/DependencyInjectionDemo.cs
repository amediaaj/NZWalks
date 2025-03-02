using System.Diagnostics;
using System.Linq.Expressions;

namespace NZWalks.API.Demo
{
    public class DependencyInjectionDemo : IMyService
    {
        private readonly int _serviceId;

        // Facilitates dependency injection by methods defined in an interface
        public interface IToolUser
        {
            void SetHammer(Hammer hammer);
            void SetSaw(Saw saw);
        }

        public class Hammer : ITool
        {
            public virtual void Use()
            {
                Debug.WriteLine("Hammering nails!");
            }
        }

        public class RubberMallet : Hammer
        {
            public override void Use()
            {
                Debug.WriteLine("Softly tapping nails.");
            }
        }

        public class Saw : ITool
        {
            public void Use()
            {
                Debug.WriteLine("Sawing wood!");
            }
        }

        public class Builder : IToolUser
        {
            private Hammer _hammer;
            private Saw _saw;

            public void SetHammer(Hammer hammer)
            {
                _hammer = hammer;
            }

            public void SetSaw(Saw saw)
            {
                _saw = saw;
            }

            public void BuildHouse()
            {
                Debug.WriteLine("Building House...");
                _hammer.Use();
                _saw.Use();
                Debug.WriteLine("House Built.");
            }
        }

        public DependencyInjectionDemo()
        {
            _serviceId = new Random().Next(100000, 999999);
        }

        public void ExecuteDemo()
        {
            Builder builder = new Builder();
            builder.SetHammer(new RubberMallet());
            builder.SetSaw(new Saw());
            builder.BuildHouse();
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }
    }
}
