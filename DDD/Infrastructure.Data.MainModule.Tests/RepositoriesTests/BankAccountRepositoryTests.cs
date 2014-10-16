using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LightstoneApp.Domain.MainModule.BankAccounts;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.MainModule.Repositories;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.Data.MainModule.Tests.RepositoriesTests
{
    [TestClass]
    public class BankAccountRepositoryTests
        : RepositoryTestsBase<BankAccount>
    {
        private int bankAccountIdentifier = 1;
        private string bankAccountNumber = "BAC0000001";

        public override Expression<Func<BankAccount, bool>> FilterExpression
        {
            get { return ba => ba.BankAccountId == bankAccountIdentifier; }
        }

        public override Expression<Func<BankAccount, int>> OrderByExpression
        {
            get { return ba => ba.BankAccountId; }
        }

        [TestMethod]
        public void FindPagedBankAccountsWithTransferInformation_Invoke_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);
            int pageIndex = 0;
            int pageCount = 10;

            //act
            IEnumerable<BankAccount> result = repository.FindPagedBankAccountsWithTransferInformation(pageIndex,
                pageCount);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void FindPagedBankAccountsWithTransferInformation_Invoke_InvalidPageIndexThrowArgumentException_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);
            int pageIndex = -1;
            int pageCount = 10;

            //act
            IEnumerable<BankAccount> result = repository.FindPagedBankAccountsWithTransferInformation(pageIndex,
                pageCount);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void FindPagedBankAccountsWithTransferInformation_Invoke_InvalidPageCountThrowArgumentException_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);
            int pageIndex = 0;
            int pageCount = 0;

            //act
            IEnumerable<BankAccount> result = repository.FindPagedBankAccountsWithTransferInformation(pageIndex,
                pageCount);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void FindBankAccount_Invoke_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);

            var spec = new BankAccountNumberSpecification(bankAccountNumber);

            //Act
            BankAccount actual;

            actual = repository.GetBySpec(spec)
                .SingleOrDefault();

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.BankAccountId == 1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindBanksAccounts_Invoke_NullSpecThrowNewArgumentNullException_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);

            repository.GetBySpec(null);
        }

        [TestMethod]
        public void FindBanksAccounts_Invoke_AccountNumber_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);
            var spec = new BankAccountSearchSpecification(bankAccountNumber, null);

            //Act
            IEnumerable<BankAccount> actual;

            actual = repository.GetBySpec(spec);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 1);
        }

        [TestMethod]
        public void FindBanksAccounts_Invoke_CustomerName_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);

            string name = "Unai";
            var spec = new BankAccountSearchSpecification(null, name);

            //Act
            IEnumerable<BankAccount> actual;

            actual = repository.GetBySpec(spec);

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void FindBanksAccounts_Invoke_CustomerIdAndAccountNumber_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);

            string name = "Cesar";
            var spec = new BankAccountSearchSpecification(bankAccountNumber, name);

            //Act
            IEnumerable<BankAccount> actual;

            actual = repository.GetBySpec(spec);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindBankAccount_Invoke_NullSpecThrowArgumentNullException_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);

            //Act
            BankAccount actual;

            actual = repository.GetBySpec(null)
                .SingleOrDefault();
        }

        [TestMethod]
        public void FindBankAccount_Invoke_InvalidCodeReturnNullObject_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            var repository = new BankAccountRepository(context, traceManager);

            string invalidCode = "0200011111";
            var spec = new BankAccountNumberSpecification(invalidCode);

            //Act
            BankAccount actual;

            actual = repository.GetBySpec(spec)
                .SingleOrDefault();

            //Assert
            Assert.IsNull(actual);
        }
    }
}