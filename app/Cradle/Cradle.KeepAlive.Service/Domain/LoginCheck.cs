using System;
using System.Linq;
using Cradle.KeepAlive.Service.Domain.Dtos;
using Cradle.KeepAlive.Service.Helpers;
using Cradle.KeepAlive.Service.Helpers.Notifications;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Newtonsoft.Json;

namespace Cradle.KeepAlive.Service.Domain
{
    public class LoginCheck : EmailAlert
    {
        public void ApiLogin()
        {
            this.Info(() => "Initiating api login check");
            try
            {
                var token = new Login().GetToken();

                if (token == null) throw new LightstoneAutoException("API Token error");

                this.Info(() => "Api login check complete");
            }
            catch (Exception e)
            {
                this.Error(() => e.Message);
                SendEmail("API Login Error", e.Message);
            }
        }

        public void MobileLogin()
        {
            this.Info(() => "Initiating mobile login check");
            try
            {
                var body = JsonConvert.DeserializeObject<ConsumerDto>(new Login().GetMobileMenu());

                if (body.Token == null && !body.Customers.Any() && !body.Clients.Any())
                {
                    throw new LightstoneAutoException("Mobile API Error");
                }

                // Customers
                if (body.Token != null && body.Customers.Any())
                {
                    if (!body.Customers.First().Contracts.Any())
                    {
                        // Contract Error
                        throw new LightstoneAutoException("Customer: {0} contract error".FormatWith(body.Customers.First().Name));
                    }

                    if (!body.Customers.First().Contracts.First().Menu.Products.Any())
                    {
                        // Products Error
                        throw new LightstoneAutoException("Customer: {0} products error".FormatWith(body.Customers.First().Name));
                    }
                }

                // Clients
                if (body.Token != null && body.Clients.Any())
                {
                    if (!body.Clients.First().Contracts.Any())
                    {
                        // Contract Error
                        throw new LightstoneAutoException("Client: {0} contract error".FormatWith(body.Clients.First().Name));
                    }
                    else
                    {
                        if (!body.Clients.First().Contracts.First().Menu.Products.Any())
                        {
                            // Products Error
                            throw new LightstoneAutoException("Client: {0} products error".FormatWith(body.Clients.First().Name));
                        }
                    }
                }
                this.Info(() => "Mobile login check complete");
            }
            catch (Exception e)
            {
                this.Error(() => e.Message);
                SendEmail("Mobile Login Error", e.Message);
            }
        }
    }
}