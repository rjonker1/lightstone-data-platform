using System;

namespace Lim.Dtos
{
    public class ConfigurationFtpDto
    {
        public ConfigurationFtpDto()
        {
            
        }

        private ConfigurationFtpDto(long id, ConfigurationDto configuration, string host, string fileName, string userName, string password,
            DateTime dateCreated, string createdBy)
        {
            Id = id;
            Configuration = configuration;
            Host = host;
            FileName = fileName;
            Username = userName;
            Password = password;
            DateCreated = dateCreated;
            CreatedBy = createdBy;
        }

        public static ConfigurationFtpDto Existing(long id, ConfigurationDto configuration, string host, string fileName, string userName, string password,
            DateTime dateCreated, string createdBy)
        {
            return new ConfigurationFtpDto(id, configuration, host, fileName, userName, password, dateCreated, createdBy);
        }

        public long Id { get; private set; }
        public ConfigurationDto Configuration { get; private set; }
        public string Host { get; private set; }
        public string FileName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string CreatedBy { get; private set; }
    }
}