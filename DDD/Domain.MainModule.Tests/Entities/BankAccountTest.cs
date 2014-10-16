using System;
using LightstoneApp.Domain.Core.Entities;
using LightstoneApp.Domain.MainModule.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Domain.MainModule.Tests.Entities
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void TransferRate_Invoke_Test()
        {
            //Arrange
            var bankAccount = new BankAccount
            {
                BankAccountId = 1,
                Balance = 1000M,
                BankAccountNumber = "A001",
                CustomerId = 1,
                Locked = false,
                BankTransfersFromThis = new TrackableCollection<BankTransfer>
                {
                    new BankTransfer
                    {
                        Amount = 100,
                        BankTransferId = 1,
                        TransferDate = DateTime.Now,
                        FromBankAccountId = 1,
                        ToBankAccountId = 2
                    }
                },
                BankTransfersToThis = new TrackableCollection<BankTransfer>
                {
                    new BankTransfer
                    {
                        Amount = 100,
                        BankTransferId = 1,
                        TransferDate = DateTime.Now,
                        FromBankAccountId = 2,
                        ToBankAccountId = 1
                    }
                }
            };

            //act
            decimal result = bankAccount.TransferRate(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));

            //Assert
            Assert.IsTrue(result == 0M);
        }

        [TestMethod]
        public void CanTransferMoney_Invoke_Test()
        {
            //Arrange
            var bankAccount = new BankAccount
            {
                BankAccountId = 1,
                Balance = 1000M,
                BankAccountNumber = "A001",
                CustomerId = 1,
                Locked = false
            };

            //Act
            bool canTransferMoney = bankAccount.CanBeCharged(100);

            //Assert
            Assert.IsTrue(canTransferMoney);
        }

        [TestMethod]
        public void CanTransferMoney_ExcesibeAmountReturnFalse_Test()
        {
            //Arrange
            var bankAccount = new BankAccount
            {
                BankAccountId = 1,
                Balance = 100M,
                BankAccountNumber = "A001",
                CustomerId = 1,
                Locked = false
            };

            //Act
            bool canTransferMoney = bankAccount.CanBeCharged(1000);

            //Assert
            Assert.IsFalse(canTransferMoney);
        }

        [TestMethod]
        public void CanTransferMoney_LockedTruetReturnFalse_Test()
        {
            //Arrange
            var bankAccount = new BankAccount
            {
                BankAccountId = 1,
                Balance = 1000M,
                BankAccountNumber = "A001",
                CustomerId = 1,
                Locked = true
            };

            //Act
            bool canTransferMoney = bankAccount.CanBeCharged(100);

            //Assert
            Assert.IsFalse(canTransferMoney);
        }
    }
}