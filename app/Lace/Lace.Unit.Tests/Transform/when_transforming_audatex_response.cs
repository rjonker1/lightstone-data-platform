﻿using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_audatex_response : Specification
    {
        //private readonly GetDataResult _audatexWebServiceResponse;
        //private TransformAudatexResponse _transformer;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ICollection<IPointToLaceRequest> _request;


        public when_transforming_audatex_response()
        {
            //_response = new SourceResponseBuilder().ForAudatexWithLaceResponse();
            //_request = new LicensePlateRequestBuilder().ForAudatex();
            //_audatexWebServiceResponse = new SourceResponseBuilder().ForAudatexWithHuyandaiHistory();
        }

        public override void Observe()
        {
            //_transformer = new TransformAudatexResponse(_audatexWebServiceResponse, _response, _request.GetFromRequest<IPointToLaceRequest>().Vehicle);
            //_transformer.Transform();
        }

        //[Observation]
        //public void audatex_transformer_continue_with_transformation_must_be_true()
        //{
        //    _transformer.Continue.ShouldBeTrue();
        //}

        //[Observation]
        //public void audatex_transformer_result_should_not_be_null()
        //{
        //    _transformer.Result.ShouldNotBeNull();
        //}

        //[Observation]
        //public void audatex_transformer_result_must_have_valid_accident_claims()
        //{
        //    _transformer.Result.AccidentClaims.ShouldNotBeNull();
        //}

        //[Observation]
        //public void audatex_transformer_result_must_have_an_accident_claims()
        //{
        //    _transformer.Result.AccidentClaims.Count.ShouldEqual(1);
        //}

        //[Observation]
        //public void audatex_transformer_result_accident_claim_must_have_valid_registration_no()
        //{
        //    _transformer.Result.AccidentClaims[0].Registration.ShouldEqual("BB30DPGP");
        //}

        //[Observation]
        //public void audatex_transfomer_result_accident_claim_must_have_valid_repair_cost_excl_vat()
        //{
        //    _transformer.Result.AccidentClaims[0].RepairCostExVat.ShouldEqual(10000);
        //}

        //[Observation]
        //public void audatex_transformer_result_accident_claim_must_have_valid_repair_cost_incl_vat()
        //{
        //    _transformer.Result.AccidentClaims[0].RepairCostIncVat.ShouldEqual(14000);
        //}


        //[Observation]
        //public void audatex_transformer_result_accident_claim_must_have_valid_vin_number()
        //{
        //    _transformer.Result.AccidentClaims[0].Vin.ShouldEqual("MALAC51HLAM496530");
        //}
       
    }
}
