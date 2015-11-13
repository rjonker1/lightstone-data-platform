using System;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Management
{
    public class CompareRequestAndResponse
    {
        private readonly bool _canApplyRepairInformation;
        private readonly bool _vinMatch;
        private readonly bool _manufacturerMatch;
        private readonly bool _licensePlateNoMatches;
        private readonly bool _vinAvailable;
        private bool _manufacturerAvailable;
        private readonly bool _claimVinAvailable;
        private readonly bool _claimManufacturerAvailable;

        private string _manufacturer;
        private readonly string _claimManufacturer;

        public CompareRequestAndResponse(string requestedVin, string manufacturer, string claimVin,
            string claimManufacturer, string requestedLicensePlateNo, string claimLicensePlateNo,
            bool canApplyRepairInformation)
        {
            _manufacturer = manufacturer;
            _claimManufacturer = CheckValue(claimManufacturer);

            _canApplyRepairInformation = canApplyRepairInformation;

            _vinMatch = ValuesMatch(CheckValue(requestedVin), CheckValue(claimVin)) || ValuesMatch(CheckValue(claimVin), CheckValue(requestedVin));
            _manufacturerMatch = CompareValue(CheckValue(manufacturer), CheckValue(claimManufacturer)) ||
                                 CompareValue(CheckValue(claimManufacturer), CheckValue(manufacturer));

            _licensePlateNoMatches = CompareValue(CheckValue(requestedLicensePlateNo), CheckValue(claimLicensePlateNo));

            _vinAvailable = !IsEmpty(requestedVin);
            _manufacturerAvailable = !IsEmpty(manufacturer);

            _claimVinAvailable = !IsEmpty(claimVin);
            _claimManufacturerAvailable = !IsEmpty(claimManufacturer);
        }

        private static string CheckValue(string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        private static bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        private static bool CompareValue(string firstValue, string secondValue)
        {
            return firstValue.Equals(secondValue, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool ValuesMatch(string firstValue, string secondValue)
        {
            return firstValue.IndexOf(secondValue, StringComparison.InvariantCultureIgnoreCase) != -1;
        }

        public string GetMatchIndicator()
        {
            if (!_canApplyRepairInformation)
                return string.Empty;

            if (_licensePlateNoMatches && !_vinMatch && !_manufacturerMatch)
                return "!";

            if (_manufacturerMatch && !_vinMatch)
                return "!";

            if (!_manufacturerMatch && _vinMatch)
                return "!";

            // rule 2
            // #  VIN field     Manufacturer field  VIN result  Manufacturer result     Outcome
            // 2  NotPopulated  IsPopulated         Nothing     Not match             ! “Indicates a low confidence in the record”
            if (!_vinAvailable && _manufacturerAvailable && !_claimVinAvailable && !_manufacturerMatch)
            {
                return "!";
            }

            // rule 3
            // #  VIN field     Manufacturer field  VIN result  Manufacturer result     Outcome
            // 3  NotPopulated  IsPopulated         Nothing     Matched                 ** “Record matched on Registration # only”
            if (!_vinAvailable && _manufacturerAvailable && !_claimVinAvailable && _manufacturerMatch)
            {
                return "**";
            }

            // rule 4
            // #  VIN field     Manufacturer field  VIN result  Manufacturer result     Outcome
            // 4  NotPopulated  NotPopulated      Nothing     Nothing                 ** “Record matched on Registration # only”
            if (!_vinAvailable && !_manufacturerAvailable && !_claimVinAvailable && !_claimManufacturerAvailable)
            {
                return "**";
            }


            return string.Empty;

        }

        public bool ShowClaim(int warrantyStartYear, DateTime? claimCreationDate)
        {
            if (claimCreationDate.HasValue)
            {
                var claimYear = claimCreationDate.Value.Year;
                if (claimYear != 1 && claimYear < warrantyStartYear)
                    return false;
            }

            if (IsEmpty(_manufacturer) && _vinMatch)
            {
                _manufacturer = _claimManufacturer;
            }

            _manufacturerAvailable = !IsEmpty(_manufacturer);

            if (_licensePlateNoMatches && !_manufacturerMatch && !_vinMatch && _vinAvailable && _claimVinAvailable)
                return false;

            // rule 1
            // #	VIN field	    Manufacturer field	VIN result	Manufacturer result	    Outcome
            // 1	IsPopulated	    IsPopulated	        Not match	Not match	            Do not display the record
            if (_vinAvailable && _manufacturerAvailable && !_vinMatch && !_manufacturerMatch)
                return false;

            // rule 5
            // #	VIN field	    Manufacturer field	VIN result	Manufacturer result	    Outcome
            // 5	IsPopulated	    NotPopulated	    Not match	Nothing	                Do not display the record
            if (_vinAvailable && !_manufacturerAvailable && !_vinMatch && !_claimManufacturerAvailable)
                return false;

            return true;
        }
    }

    //public class CompareRequestedAndResponseData
    //{

    //    //public static string MatchInformation(string requestedVin, string manufacturer, string claimVin,
    //    //    string claimManufacturer, string requestedLicensePlateNo, string claimLicensePlateNo,
    //    //    bool canApplyRepairInformation)
    //    //{
    //    //    if (!canApplyRepairInformation)
    //    //        return string.Empty;


    //    //    requestedLicensePlateNo = string.IsNullOrEmpty(requestedLicensePlateNo)
    //    //        ? string.Empty
    //    //        : requestedLicensePlateNo;
    //    //    claimLicensePlateNo = string.IsNullOrEmpty(claimLicensePlateNo) ? string.Empty : claimLicensePlateNo;

    //    //    requestedVin = string.IsNullOrEmpty(requestedVin) ? string.Empty : requestedVin;
    //    //    manufacturer = string.IsNullOrEmpty(manufacturer) ? string.Empty : manufacturer;
    //    //    claimVin = string.IsNullOrEmpty(claimVin) ? string.Empty : claimVin;
    //    //    claimManufacturer = string.IsNullOrEmpty(claimManufacturer) ? string.Empty : claimManufacturer;

    //    //    var vinAvailable = !string.IsNullOrEmpty(requestedVin);
    //    //    var manufacturerAvailable = !string.IsNullOrEmpty(manufacturer);

    //    //    var vinMatch = requestedVin.IndexOf(claimVin, StringComparison.InvariantCultureIgnoreCase) != -1 ||
    //    //                   claimVin.IndexOf(requestedVin, StringComparison.InvariantCultureIgnoreCase) != -1;

    //    //    var claimVinAvailable = !string.IsNullOrEmpty(claimVin);
    //    //    var claimManufacturerAvailable = !string.IsNullOrEmpty(claimManufacturer);
    //    //    var manufacturerMatch =
    //    //        manufacturer.Equals(claimManufacturer, StringComparison.InvariantCultureIgnoreCase) ||
    //    //        claimManufacturer.Equals(manufacturer, StringComparison.InvariantCultureIgnoreCase);
    //    //    var licensePlateNoMatches = requestedLicensePlateNo.Equals(claimLicensePlateNo,
    //    //        StringComparison.InvariantCultureIgnoreCase);


           
    //    //    if (licensePlateNoMatches && !vinMatch && !manufacturerMatch)
    //    //        return "!";

    //    //    if (manufacturerMatch && !vinMatch)
    //    //        return "!";

    //    //    if (!manufacturerMatch && vinMatch)
    //    //        return "!";

    //    //    // rule 2
    //    //    // #	VIN field	    Manufacturer field	VIN result	Manufacturer result	    Outcome
    //    //    // 2	NotPopulated	IsPopulated	        Nothing	    Not match	            ! “Indicates a low confidence in the record”
    //    //    if (!vinAvailable && manufacturerAvailable && !claimVinAvailable && !manufacturerMatch)
    //    //    {
    //    //        return "!";
    //    //    }

    //    //    // rule 3
    //    //    // #	VIN field	    Manufacturer field	VIN result	Manufacturer result	    Outcome
    //    //    // 3	NotPopulated	IsPopulated	        Nothing	    Matched	                ** “Record matched on Registration # only”
    //    //    if (!vinAvailable && manufacturerAvailable && !claimVinAvailable && manufacturerMatch)
    //    //    {
    //    //        return "**";
    //    //    }

    //    //    // rule 4
    //    //    // #	VIN field	    Manufacturer field	VIN result	Manufacturer result	    Outcome
    //    //    // 4	NotPopulated	NotPopulated	    Nothing	    Nothing	                ** “Record matched on Registration # only”
    //    //    if (!vinAvailable && !manufacturerAvailable && !claimVinAvailable && !claimManufacturerAvailable)
    //    //    {
    //    //        return "**";
    //    //    }


    //    //    return string.Empty;
    //    //}

    //    //public static bool ShowClaim(string requestedVin, string manufacturer, string claimVIN, string claimManufacturer,
    //    //    int warrantyStartYear, DateTime? claimCreationDate, string requestedLicensePlateNo,
    //    //    string claimLicensePlateNo)
    //    //{
    //    //    if (claimCreationDate.HasValue)
    //    //    {
    //    //        var claimYear = claimCreationDate.Value.Year;

    //    //        if (claimYear != 1 && claimYear < warrantyStartYear)
    //    //            return false;
    //    //    }

    //    //    requestedLicensePlateNo = string.IsNullOrEmpty(requestedLicensePlateNo)
    //    //        ? string.Empty
    //    //        : requestedLicensePlateNo;
    //    //    claimLicensePlateNo = string.IsNullOrEmpty(claimLicensePlateNo) ? string.Empty : claimLicensePlateNo;

    //    //    requestedVin = string.IsNullOrEmpty(requestedVin) ? string.Empty : requestedVin;
    //    //    manufacturer = string.IsNullOrEmpty(manufacturer) ? string.Empty : manufacturer;

    //    //    claimVIN = string.IsNullOrEmpty(claimVIN) ? string.Empty : claimVIN;
    //    //    claimManufacturer = string.IsNullOrEmpty(claimManufacturer) ? string.Empty : claimManufacturer;
    //    //    var licensePlateNoMatches = requestedLicensePlateNo.Equals(claimLicensePlateNo,
    //    //        StringComparison.InvariantCultureIgnoreCase);

    //    //    var vinAvailable = !string.IsNullOrEmpty(requestedVin);
    //    //    var claimVinAvailable = !string.IsNullOrEmpty(claimVIN);


    //    //    var vinMatch = requestedVin.IndexOf(claimVIN, StringComparison.InvariantCultureIgnoreCase) != -1 ||
    //    //                   claimVIN.IndexOf(requestedVin, StringComparison.InvariantCultureIgnoreCase) != -1;

    //    //    if (string.IsNullOrEmpty(manufacturer) && vinMatch)
    //    //    {
    //    //        manufacturer = claimManufacturer;
    //    //    }

    //    //    var manufacturerAvailable = !string.IsNullOrEmpty(manufacturer);
    //    //    var claimManufacturerAvailable = !string.IsNullOrEmpty(claimManufacturer);
    //    //    var manufacturerMatch =
    //    //        manufacturer.Equals(claimManufacturer, StringComparison.InvariantCultureIgnoreCase) ||
    //    //        claimManufacturer.Equals(manufacturer, StringComparison.InvariantCultureIgnoreCase);

    //    //    if (licensePlateNoMatches && !manufacturerMatch && !vinMatch && vinAvailable && claimVinAvailable)
    //    //        return false;

    //    //    // rule 1
    //    //    // #	VIN field	    Manufacturer field	VIN result	Manufacturer result	    Outcome
    //    //    // 1	IsPopulated	    IsPopulated	        Not match	Not match	            Do not display the record
    //    //    if (vinAvailable && manufacturerAvailable && !vinMatch && !manufacturerMatch)
    //    //        return false;

    //    //    // rule 5
    //    //    // #	VIN field	    Manufacturer field	VIN result	Manufacturer result	    Outcome
    //    //    // 5	IsPopulated	    NotPopulated	    Not match	Nothing	                Do not display the record
    //    //    if (vinAvailable && !manufacturerAvailable && !vinMatch && !claimManufacturerAvailable)
    //    //        return false;


    //    //    return true;
    //    //}
    //}
}
