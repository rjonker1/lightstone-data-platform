using Lace.Request;

namespace Lace.Tests.Data
{
    public class RegistrationField : IField
    {
        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "Registration";
            }
        }
    }

    public class VinField : IField
    {

        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "Vin";
            }
        }
    }

    public class EngineField : IField
    {

        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "Engine";
            }
        }
    }

    public class MakeDescription : IField
    {
        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "MakeDescription";
            }
        }
    }
}
