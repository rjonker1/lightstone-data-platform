using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestJisInformation : IHaveJisInformation
    {
        public string CroppedImage
        {
            get { return string.Empty; }
        }

        public string FullImage
        {
            get { return string.Empty;  }
        }

        public string FullImageThumb
        {
            get { return string.Empty;  }
        }

        public double Latitude
        {
            get { return 0;  }
        }

        public double Longitude
        {
            get { return 0;  }
        }

        public DateTime SightingDate
        {
            get { return DateTime.MinValue;  }
        }

        public string SiteLocation
        {
            get { return string.Empty;  }
        }

        public string SiteName
        {
            get { return string.Empty;  }
        }

        public int SessionId
        {
            get { return 0;  }
        }

        public string UserName
        {
            get { return string.Empty;  }
        }

        public string LicensePlateNumber
        {
            get { return string.Empty;  }
        }
    }
}
