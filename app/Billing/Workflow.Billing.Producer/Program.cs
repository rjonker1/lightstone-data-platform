using System;
using Castle.Windsor;
using EasyNetQ;
using Shared.Configuration;
//using Workflow.Billing.Messages;
//using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Messages;
using Workflow.Billing.Producer.Installers;

namespace Workflow.Billing.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = new AppSettings();


            var container = new WindsorContainer().Install(new BusInstaller());
            var bus = container.Resolve<IBus>();

            var input = "";
            Console.WriteLine("Enter a message. 'Quit' to quit.");
            while ((input = Console.ReadLine()) != "Quit")
            {
                var message = new TextMessage() { Text = input };
                bus.Publish(message);
            }
        }
    }
}
