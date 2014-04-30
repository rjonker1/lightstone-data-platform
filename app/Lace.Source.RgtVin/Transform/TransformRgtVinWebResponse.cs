using System;
using System.Collections.Generic;
using Lace.Models.RgtVin.Dto;

namespace Lace.Source.RgtVin.Transform
{
    public class TransformRgtVinWebResponse : ITransform
    {
        private readonly string _message;
        public RgtVinResponse Result { get; private set; }
        public bool Continue { get; private set; }

        private Dictionary<string, string> _data;

        public TransformRgtVinWebResponse(string response)
        {
            Continue = !string.IsNullOrEmpty(response);
            Result = Continue ? new RgtVinResponse() : null;
            _message = response;
        }

        public void Transform()
        {
            _data = new Dictionary<string, string>();
            var rows = _message.Split(new char[]
            {
                '#'
            }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length > 0)
            {
                var columnNames = rows[0].Split(new char[]
                {
                    '|'
                }, StringSplitOptions.RemoveEmptyEntries);

                var values = rows[1].Split(new char[]
                {
                    '|'
                }, StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < columnNames.Length; i += 1)
                {
                    if ((i < columnNames.Length) && (i < values.Length))
                    {
                        _data[columnNames[i].ToLower().Trim()] = values[i].Trim();
                    }
                }

                Result.Colour = GetStringValue("colour");
                Result.Month = GetIntValue("month");
                Result.Price = GetDecimalValue("price");
                Result.Quarter = GetIntValue("qtr");
                Result.RgtCode = GetIntValue("rgtcode");
                Result.VehicleMake = GetStringValue("make");
                Result.VehicleModel = GetStringValue("model");
                Result.VehicleType = GetStringValue("type");
                Result.Vin = GetStringValue("vin");
                Result.Year = GetIntValue("year");

            }
            else
            {
                throw new Exception(
                    string.Format(
                        "Unexpected message format from RGT VIN service '{0}' was expected to have 1 or more '# ",
                        _message));
            }
        }

        private string GetStringValue(string key)
        {
            return !_data.ContainsKey(key) ? string.Empty : _data[key];
        }

        private int GetIntValue(string key)
        {
            if (!_data.ContainsKey(key)) return 0;

            int result;
            return int.TryParse(_data[key], out result) ? result : 0;
        }

        private decimal GetDecimalValue(string key)
        {
            if (!_data.ContainsKey(key)) return 0;

            decimal result;
            return decimal.TryParse(_data[key], out result) ? result : 0;
        }
    }
}
