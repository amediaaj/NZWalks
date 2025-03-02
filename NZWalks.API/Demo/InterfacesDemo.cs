using System.Diagnostics;

namespace NZWalks.API.Demo
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Debug.WriteLine($"Processing credit card payment of amount: {amount}");
            // Implement credit card payment logic.
        }
    }

    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Debug.WriteLine($"Processing PayPal payment of amount: {amount}");
            // Implement PayPal payment logic.
        }
    }

    public class PaymentService
    {
        private readonly IPaymentProcessor _processor;

        public PaymentService(IPaymentProcessor processor)
        {
            _processor = processor;
        }

        public void ProcessOrderPayment(decimal amount)
        {
            _processor.ProcessPayment(amount);
        }
    }

    public class InterfacesDemo : IMyService
    {
        private readonly IPaymentProcessor _processor;
        private readonly int _serviceId;

        public InterfacesDemo(IPaymentProcessor processor)
        {
            _serviceId = new Random().Next(100000, 999999);
            _processor = processor;
        }

        public void ExecuteDemo()
        {
            PaymentService paymentService = new PaymentService(_processor);
            paymentService.ProcessOrderPayment(5.99m);
        }

        public void LogCreation(string message)
        {
            Debug.WriteLine($"\n{message} - Service ID: {_serviceId}");
        }
    }
}
