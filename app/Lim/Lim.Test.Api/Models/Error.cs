using System;
using System.Runtime.Serialization;

namespace Lim.Test.Api.Models
{
    [DataContract]
    public class Error
    {
        public Error(Guid id, string message, string attemptedAction, DateTime when)
        {
            Id = id;
            Message = message;
            AttemptedAction = attemptedAction;
            When = when;
        }

        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public string AttemptedAction { get; private set; }
        public DateTime When { get; private set; }
    }
}