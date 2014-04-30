﻿namespace Lace.Models.Audatex.Dto
{
    public class HistoryCheckRequestBody
    {
        public string VIN { get; set; }

        public string EngineNumber { get; set; }

        public string Registration { get; set; }

        public string ClaimReferenceNumber { get; set; }

        public string AssessmentNumber { get; set; }

        public string Originator { get; set; }

        public HistoryCheckRequestBody()
        {
            VIN = string.Empty;
            EngineNumber = string.Empty;
            Registration = string.Empty;
            ClaimReferenceNumber = string.Empty;
            AssessmentNumber = string.Empty;
            Originator = string.Empty;
        }
    }
}
