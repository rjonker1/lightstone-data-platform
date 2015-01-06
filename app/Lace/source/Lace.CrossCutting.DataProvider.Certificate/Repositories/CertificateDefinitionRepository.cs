using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Lace.CrossCutting.DataProviderCommandSource.Certificate.Infrastructure.Dto;
using Lace.Shared.Extensions;

namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Repositories
{
    public class CertificateRepository : IReadOnlyRepository<CoOrdinateCertificate>
    {

        private readonly string _fileName;

        public CertificateRepository(string fileName)
        {
            _fileName = fileName;
        }

        public CoOrdinateCertificate Find(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public CoOrdinateCertificate[] GetAll()
        {
            var xml = File.ReadAllText(_fileName);
            var certDefinitions = xml.XmlToObject<List<CertificateDefinition>>();

            if (certDefinitions == null || !certDefinitions.Any())
                return new CoOrdinateCertificate[] { };

            return certDefinitions
                .Where(w => w.IsActive)
                .Select(
                    s =>
                        new CoOrdinateCertificate(s.Name, s.DisplayName, s.IsActive, s.IsDefault, s.Description,
                            new CertificateProximity(s.Proximity.Latitude, s.Proximity.Longitude, s.Proximity.Radius),
                            new CertificateCredentials(s.Credentials.Domain, s.Credentials.Username,
                                s.Credentials.Password), s.Endpoint)).ToArray();
        }

        private class CertificateDefinition
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }

            [XmlAttribute("DisplayName")]
            public string DisplayName { get; set; }

            [XmlAttribute("IsActive")]
            public bool IsActive { get; set; }

            [XmlAttribute("IsDefault")]
            public bool IsDefault { get; set; }

            public string Description { get; set; }
            public Proximity Proximity { get; set; }
            public Credentials Credentials { get; set; }
            public string Endpoint { get; set; }
        }

        private class Proximity
        {

            [XmlAttribute("Latitude")]
            public double Latitude { get; set; }

            [XmlAttribute("Longitude")]
            public double Longitude { get; set; }

            [XmlAttribute("Radius")]
            public double Radius { get; set; }
        }

        private class Credentials
        {

            [XmlAttribute("Domain")]
            public string Domain { get; set; }

            [XmlAttribute("Username")]
            public string Username { get; set; }

            [XmlAttribute("Password")]
            public string Password { get; set; }
        }
    }
}
