using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Workflow.Billing.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<IBillingService>(s =>
                {
                    s.ConstructUsing(name => new BillingService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Billing.service");
                x.SetDisplayName("Billing.Service");
                x.SetServiceName("Billing.Service");
            });
        }
    }
}
