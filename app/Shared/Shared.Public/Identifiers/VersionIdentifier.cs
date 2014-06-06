using System;

namespace DataPlatform.Shared.Public.Identifiers
{
    public class VersionIdentifier
    {
        public int Number { get; private set; }
        public DateTime Date { get; private set; }

        public VersionIdentifier(int number, DateTime date)
        {
            Number = number;
            Date = date;
        }
    }
}