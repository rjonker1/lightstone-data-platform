using System;
using Microsoft.Owin.Hosting;

namespace Cradle.KeepAlive.Service
{
    public class KeepAliveService : IKeepAliveService
    {
        public void Start()
        {
            var url = "http://+:8080";

            WebApp.Start<StartupBootstrapper>(url);
            Console.WriteLine("Running on {0}", url);
            Console.WriteLine("Press Ctrl + c to exit");
            Console.ReadLine();
        }

        public void Stop()
        {

        }
    }
}