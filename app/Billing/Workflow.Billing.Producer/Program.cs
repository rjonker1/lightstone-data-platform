using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using EasyNetQ;
using Shared.Configuration;
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
