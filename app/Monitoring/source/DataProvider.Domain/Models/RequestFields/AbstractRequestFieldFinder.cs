using System.Collections.Generic;
using DataProvider.Domain.Enums;
using Newtonsoft.Json.Linq;

namespace DataProvider.Domain.Models.RequestFields
{
    public interface IFindRequestField
    {
        void DetermineRequestField(JObject obj, List<RequestFieldType> requestFields);
    }

    public abstract class AbstractRequestFieldFinder : IFindRequestField
    {
        private readonly IFindRequestField _next;
        private readonly RequestFieldType _requestField;

        protected AbstractRequestFieldFinder(RequestFieldType requestField)
        {
            _requestField = requestField;
        }

        protected AbstractRequestFieldFinder(IFindRequestField next, RequestFieldType requestField)
            : this(requestField)
        {
            _next = next;
        }

        public void DetermineRequestField(JObject obj, List<RequestFieldType> requestFields)
        {
            try
            {
                var check = !requestFields.Exists(w => w == _requestField) && obj != null && obj.HasValues && obj.GetValue(_requestField.ToString()).HasValues;
                if (check)
                    requestFields.Add(_requestField);
            }
            catch
            {
                
            }
            finally
            {
                if (_next != null)
                    _next.DetermineRequestField(obj, requestFields);
            }

        }
    }
}