using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using Lim.Enums;

namespace Lim.Domain.ConfigurationTypes
{
    [DataContract]
    public class RestApiConfiguration
    {
        public static readonly IntegrationType IntegrationType = IntegrationType.Api;


        public RestApiConfiguration(IntegrationAction action, AuthenticationType authenticationType,
            IEnumerable<RestQueryParameter> parameters, string baseAddress, string suffix, bool hasAuthentication,
            string username = "", string password = "")
        {
            Action = action;
            AuthenticationType = authenticationType;
            Parameters = parameters;
            BaseAddress = baseAddress;
            Suffix = suffix;
            HasAuthentication = hasAuthentication;
            Username = username;
            Password = password;
        }


        [DataMember]
        public IntegrationAction Action { get; private set; }

        [DataMember]
        public AuthenticationType AuthenticationType { get; private set; }

        [DataMember]
        public IEnumerable<RestQueryParameter> Parameters { get; private set; }

        [DataMember]
        public string BaseAddress { get; private set; }

        [DataMember]
        public string Suffix { get; private set; }

        [DataMember]
        public bool HasAuthentication { get; private set; }

        [DataMember]
        public bool HasParameters { get; private set; }

        [DataMember]
        public string Username { get; private set; }

        [DataMember]
        public string Password { get; private set; }

        [DataMember]
        public AuthenticationHeaderValue BasicAuthenticationHeaderValue
        {
            get
            {
                return new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(Username + ":" + Password)));
            }
        }


        [DataMember]
        public string BasicAuthenticationHeaderString
        {
            get
            {
                return string.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(Username + ":" + Password)));
            }
        }
    }

    [DataContract]
    public class RestQueryParameter
    {
        public RestQueryParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string Value { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}={1}&", Name, Value);
        }

        public string FirstParameter()
        {
            return "?" + ToString();
        }

        public string OneParameter()
        {
            return "?" + GetOneParameter();
        }

        public string GetOneParameter()
        {
            return ToString().Remove(ToString().LastIndexOf('&'));
        }
    }

   
}
