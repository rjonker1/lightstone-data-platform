using System.Diagnostics;
using Lace.Functions.Json;
using Lace.Request;
using Lace.Shared.Tests.Data;
using Xunit.Extensions;

namespace Lace.Shared.Tests
{
    public class helper_json_converter_tests : Specification
    {
        private readonly ILaceRequest _request;
        private string _result;
        public helper_json_converter_tests()
        {
            _request = new LicensePlateNumberIvidOnlyRequest();
        }

        public override void Observe()
        {
            _result = JsonFunctions.JsonFunction.ObjectToJson(_request);
        }

        [Observation]
        public void request_must_be_converted_to_json_test()
        {
           
            _result.ShouldNotBeNull();

            _result.Length.ShouldNotEqual(0);
            Debug.WriteLine(_result);


        }
    }
}
