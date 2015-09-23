using System;
using System.Collections.Generic;
using System.Data;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Management
{
    public sealed class TransformLightstonePropertyResponse : ITransform
    {
        public DataSet Response { get; private set; }
        public IProvideDataFromLightstoneProperty Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformLightstonePropertyResponse(DataSet response)
        {
            Response = response;
            Continue = Response != null && Response.Tables.Count > 0;
        }

        public void Transform()
        {
            var properties = new List<IRespondWithProperty>();

            var property = Response.Tables["Properties"].AsEnumerable()
                .Select(s => new PropertyModel(
                    GetIntRowValue(s, "sr_id"),
                    GetDecimalRowValue(s, "prop_id"),
                    GetDecimalRowValue(s, "PROPTYPE_ID"),
                    GetDecimalRowValue(s, "SS_ID"),
                    GetStringRowValue(s, "property_type"),
                    GetStringRowValue(s, "PROVINCE"),
                    GetStringRowValue(s, "MUNICNAME"),
                    GetStringRowValue(s, "DEEDTOWN"),
                    GetStringRowValue(s, "FARMNAME"),
                    GetStringRowValue(s, "SECTIONAL_TITLE"),
                    GetIntRowValue(s, "UNIT"),
                    GetDecimalRowValue(s, "PORTION"),
                    GetStringRowValue(s, "BUYER_NAME"),
                    GetStringRowValue(s, "FIRSTNAME"),
                    GetStringRowValue(s, "MIDDLENAME"),
                    GetStringRowValue(s, "MIDDLENAME2"),
                    GetStringRowValue(s, "MIDDLENAME3"),
                    GetStringRowValue(s, "SURNAME"),
                    GetStringRowValue(s, "PERSON_TYPE_ID"),
                    GetStringRowValue(s, "BUYER_IDCK"),
                    GetDecimalRowValue(s, "MUNIC_ID"),
                    GetDecimalRowValue(s, "PROV_ID"),
                    GetStringRowValue(s, "STREET_NUMBER"),
                    GetStringRowValue(s, "STREET_TYPE"),
                    GetStringRowValue(s, "PO_CODE"),
                    GetGuidRowValue(s, "user_id"),
                    GetIntRowValue(s, "GARAGE"),
                    GetStringRowValue(s, "SS_Number"),
                    GetIntRowValue(s, "SS_UnitNoFrom"),
                    GetIntRowValue(s, "SS_UnitTo"),
                    GetDoubleRowValue(s, "Size"),
                    GetDoubleRowValue(s, "X"),
                    GetDoubleRowValue(s, "Y"),
                    GetStringRowValue(s, "SUBURB"),
                    GetStringRowValue(s, "Title_Deed_No"),
                    GetStringRowValue(s, "Reg_Date"),
                    GetStringRowValue(s, "TownShip"),
                    GetIntRowValue(s, "Purchase_Price"),
                    GetIntRowValue(s, "Purchase_Date"),
                    GetStringRowValue(s, "Bond_Number"),
                    GetStringRowValue(s, "Township_alt"),
                    GetStringRowValue(s, "ADD_Description"),
                    GetIntRowValue(s, "sub_id"),
                    GetIntRowValue(s, "street_id"),
                    GetStringRowValue(s, "Active_Status"),
                    GetStringRowValue(s, "Estate_Name"),
                    GetIntRowValue(s, "est_id"),
                    GetIntRowValue(s, "ReqStatus_ID"),
                    GetBoolRowValue(s, "estimatedcad")));

            properties.AddRange(property);
            Result = new LightstonePropertyResponse(properties);
        }

        private static string GetStringRowValue(DataRow row, string value)
        {
            return row[value].ToString();
        }

        private static decimal GetDecimalRowValue(DataRow row, string value)
        {
            decimal @decimal;
            return decimal.TryParse(row[value].ToString(), out @decimal) ? @decimal : 0;
        }

        private static int GetIntRowValue(DataRow row, string value)
        {
            int @int;
            return int.TryParse(row[value].ToString(), out @int) ? @int : 0;
        }

        private static Guid GetGuidRowValue(DataRow row, string value)
        {
            Guid @guid;
            return Guid.TryParse(row[value].ToString(), out @guid) ? @guid : Guid.Empty;
        }

        private static double GetDoubleRowValue(DataRow row, string value)
        {
            double @double;
            return double.TryParse(row[value].ToString(), out @double) ? @double : 0.0;
        }

        private static bool GetBoolRowValue(DataRow row, string value)
        {
            bool @bool;
            return bool.TryParse(row[value].ToString(), out @bool) ? @bool : false;
        }
    }
}
