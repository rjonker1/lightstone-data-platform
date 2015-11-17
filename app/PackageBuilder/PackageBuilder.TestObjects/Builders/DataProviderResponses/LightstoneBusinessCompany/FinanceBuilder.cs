﻿using System;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class FinanceBuilder
    {
        private int _registrationYear;
        private string _dealReference;
        private DateTime _startDate;
        private DateTime _expireDate;
        private string _chassis;
        private string _dealStatus;
        private string _description;
        private string _engine;
        private string _financeHouse;
        private string _productCategory;
        private string _registrationNumber;
        private string _accoutnNumberReference;
        private string _clientNumber;

        public IRespondWithBmwFinance Build()
        {
            return new BmwFinanceRecord(_financeHouse, _dealReference, _startDate, _expireDate, _chassis, _engine, _registrationNumber, _description, _registrationYear, _productCategory, _dealStatus, _clientNumber,_accoutnNumberReference);
        }

        public FinanceBuilder With(int registrationYear, string dealReference)
        {
            _registrationYear = registrationYear;
            _dealReference = dealReference;
            return this;
        }

        public FinanceBuilder With(DateTime startDate, DateTime expireDate)
        {
            _startDate = startDate;
            _expireDate = expireDate;
            return this;
        }

        public FinanceBuilder With(string chassis,
         string dealStatus,
         string description,
         string engine,
         string financeHouse,
         string productCategory,
         string registrationNumber,
            string clientNumber,
            string accountReference)
        {
            _chassis = chassis;
            _dealStatus = dealStatus;
            _description = description;
            _engine = engine;
            _financeHouse = financeHouse;
            _productCategory = productCategory;
            _registrationNumber = registrationNumber;
            _accoutnNumberReference = accountReference;
            _clientNumber = clientNumber;

            return this;
        }
    }
}