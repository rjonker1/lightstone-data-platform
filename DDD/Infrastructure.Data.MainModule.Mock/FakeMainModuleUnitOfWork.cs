using System;
using System.Collections.Generic;
using System.Data.Objects;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.Data.Core.Extensions;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Stubs;

namespace LightstoneApp.Infrastructure.Data.MainModule.Mock
{
    /// <summary>
    ///     Fake container for testing purposes.
    ///     Implemented with Microsoft Moles and Stubs
    /// </summary>
    public class FakeMainModuleUnitOfWork
        : StubIMainModuleUnitOfWork
    {
        #region Members

        private static List<BankAccount> _BankAccounts;
        private static List<BankTransfer> _BankTransfer;
        private static List<Country> _Countries;
        private static List<Product> _Products;
        private static List<Order> _Orders;
        private static List<Customer> _Customers;
        private static List<OrderDetail> _OrdersDetails;

        #endregion

        #region Constructor

        public FakeMainModuleUnitOfWork()
        {
            //Set default behavior for not stubbed elements ( DEFAULT BEHAVIOR THROW NOT IMPLEMENTED EXCEPTION)
            InstanceBehavior = StubBehaviors.DefaultValue;

            InitiateInnerCollection();
            InitiateFakeData();
        }

        #endregion

        #region Methods for configure Fake for testing

        private void InitiateInnerCollection()
        {
            if (_Countries == null)
            {
                _Countries = new List<Country>
                {
                    new Country {CountryId = 1, CountryName = "Spain"},
                    new Country {CountryId = 2, CountryName = "United States"},
                    new Country {CountryId = 3, CountryName = "United Kingdom"},
                    new Country {CountryId = 4, CountryName = "Germany"},
                    new Country {CountryId = 5, CountryName = "France"},
                    new Country {CountryId = 6, CountryName = "Sweeden"},
                    new Country {CountryId = 7, CountryName = "Norway"},
                    new Country {CountryId = 8, CountryName = "Portugal"},
                    new Country {CountryId = 9, CountryName = "Italy"},
                    new Country {CountryId = 10, CountryName = "Holland"},
                    new Country {CountryId = 11, CountryName = "Belgium"},
                    new Country {CountryId = 12, CountryName = "Brazil"},
                    new Country {CountryId = 13, CountryName = "Argentina"},
                    new Country {CountryId = 14, CountryName = "Russia"},
                    new Country {CountryId = 15, CountryName = "China"}
                };
            }
            if (_Customers == null)
            {
                _Customers = new List<Customer>
                {
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerCode = "A0001",
                        ContactTitle = "DPE Architect Evangelist",
                        CompanyName = "Microsoft",
                        ContactName = "Cesar de la Torre",
                        Address = new AddressInformation
                        {
                            Telephone = "+34981666666",
                            PostalCode = "28081",
                            Fax = "+34981666666",
                            City = "Madrid",
                            Address = "Parque empresaria deLa Finca"
                        },
                        CountryId = 1,
                        Country = _Countries[0],
                        IsEnabled = true,
                        CustomerPicture = new CustomerPicture {CustomerId = 1, Photo = null}
                    },
                    new Customer
                    {
                        CustomerId = 2,
                        CustomerCode = "A0002",
                        ContactTitle = "Developer Team Leader",
                        CompanyName = "Plain Concepts",
                        ContactName = "Unai Zorrilla",
                        Address = new AddressInformation
                        {
                            Telephone = "+34981555000",
                            PostalCode = "28081",
                            Fax = "+34981555001",
                            City = "Madrid",
                            Address = "Sebastian el Cano"
                        },
                        CountryId = 2,
                        Country = _Countries[1],
                        IsEnabled = true,
                        CustomerPicture = new CustomerPicture {CustomerId = 2, Photo = null}
                    },
                    new Customer
                    {
                        CustomerId = 3,
                        CustomerCode = "A0003",
                        ContactTitle = "Developer Advisor",
                        CompanyName = "Plain Concepts",
                        ContactName = "Fernando Cortés",
                        Address = new AddressInformation
                        {
                            Telephone = "+34981555000",
                            PostalCode = "28081",
                            Fax = "+34981555001",
                            City = "Madrid",
                            Address = "Sebastian el Cano"
                        },
                        CountryId = 2,
                        Country = _Countries[1],
                        IsEnabled = false,
                        CustomerPicture = new CustomerPicture {CustomerId = 3, Photo = null}
                    },
                    new Customer
                    {
                        CustomerId = 4,
                        CustomerCode = "A0004",
                        ContactTitle = "ALM Team Lead",
                        CompanyName = "Plain Concepts",
                        ContactName = "Rodrigo Corral",
                        Address = new AddressInformation
                        {
                            Telephone = "+34981555000",
                            PostalCode = "28081",
                            Fax = "+34981555001",
                            City = "Madrid",
                            Address = "Sebastian el Cano"
                        },
                        CountryId = 2,
                        Country = _Countries[1],
                        IsEnabled = true,
                        CustomerPicture = new CustomerPicture {CustomerId = 4, Photo = null}
                    }
                };

                _Customers[0].Orders.Add(new Order {OrderId = 1});
            }
            if (_Products == null)
            {
                _Products = new List<Product>
                {
                    new Software
                    {
                        ProductId = 2,
                        UnitPrice = 200M,
                        UnitAmount = "1",
                        ProductDescription = "Windows Seven Operating System",
                        LicenseCode = "ABCX-0002-33333-66666",
                        AmountInStock = 20
                    },
                    new Book
                    {
                        ProductId = 1,
                        UnitPrice = 40M,
                        UnitAmount = "1",
                        ProductDescription = "Book for ADO.NET Entity Framework",
                        Publisher = "Krasis Press",
                        AmountInStock = 20
                    }
                };
            }


            if (_BankAccounts == null)
            {
                _BankAccounts = new List<BankAccount>
                {
                    new BankAccount
                    {
                        BankAccountId = 1,
                        BankAccountNumber = "BAC0000001",
                        CustomerId = 1,
                        Balance = 100,
                        Locked = false,
                        Customer = _Customers[0]
                    },
                    new BankAccount
                    {
                        BankAccountId = 2,
                        BankAccountNumber = "BAC0000002",
                        CustomerId = 2,
                        Balance = 200,
                        Locked = false,
                        Customer = _Customers[1]
                    },
                    new BankAccount
                    {
                        BankAccountId = 3,
                        BankAccountNumber = "BAC0000003",
                        CustomerId = 2,
                        Balance = 200,
                        Locked = true,
                        Customer = _Customers[2]
                    }
                };
            }
            if (_BankTransfer == null)
            {
                _BankTransfer = new List<BankTransfer>
                {
                    new BankTransfer
                    {
                        BankTransferId = 1,
                        Amount = 50,
                        FromBankAccountId = 1,
                        ToBankAccountId = 2,
                        TransferDate = new DateTime(2009, 1, 1)
                    },
                    new BankTransfer
                    {
                        BankTransferId = 1,
                        Amount = 50,
                        FromBankAccountId = 2,
                        ToBankAccountId = 1,
                        TransferDate = new DateTime(2009, 5, 1)
                    },
                };
            }


            if (_Orders == null)
            {
                _Orders = new List<Order>
                {
                    new Order
                    {
                        OrderId = 1,
                        DeliveryDate = new DateTime(2010, 1, 2),
                        ShippingAddress = "Sebastian el Cano",
                        ShippingCity = "Madrid",
                        ShippingName = "Book EF buy",
                        ShippingZip = "28081",
                        OrderDate = new DateTime(2010, 1, 1),
                        Customer = _Customers[0]
                    },
                    new Order
                    {
                        OrderId = 2,
                        DeliveryDate = new DateTime(2010, 5, 6),
                        ShippingAddress = "Sebastian el Cano",
                        ShippingCity = "Madrid",
                        ShippingName = "Windows Seven buy",
                        ShippingZip = "28081",
                        OrderDate = new DateTime(2010, 5, 1),
                        Customer = _Customers[1]
                    },
                    new Order
                    {
                        OrderId = 3,
                        DeliveryDate = new DateTime(2010, 2, 5),
                        ShippingAddress = "Sebastian el Cano",
                        ShippingCity = "Madrid",
                        ShippingName = "Book EF buy",
                        ShippingZip = "28081",
                        OrderDate = new DateTime(2010, 2, 1),
                        Customer = _Customers[0]
                    },
                    new Order
                    {
                        OrderId = 4,
                        DeliveryDate = new DateTime(2010, 1, 5),
                        ShippingAddress = "Sebastian el Cano",
                        ShippingCity = "Madrid",
                        ShippingName = "Book EF buy",
                        ShippingZip = "28081",
                        OrderDate = new DateTime(2010, 1, 1),
                        Customer = _Customers[0]
                    },
                    new Order
                    {
                        OrderId = 5,
                        DeliveryDate = new DateTime(2010, 6, 5),
                        ShippingAddress = "Sebastian el Cano",
                        ShippingCity = "Madrid",
                        ShippingName = "Book EF buy",
                        ShippingZip = "28081",
                        OrderDate = new DateTime(2010, 6, 1),
                        Customer = _Customers[0]
                    },
                    new Order
                    {
                        OrderId = 6,
                        DeliveryDate = new DateTime(2010, 4, 5),
                        ShippingAddress = "Sebastian el Cano",
                        ShippingCity = "Madrid",
                        ShippingName = "Book EF buy",
                        ShippingZip = "28081",
                        OrderDate = new DateTime(2010, 4, 1),
                        Customer = _Customers[0]
                    },
                };
            }

            if (_OrdersDetails == null)
            {
                _OrdersDetails = new List<OrderDetail>
                {
                    new OrderDetail
                    {
                        OrderDetailsId = 1,
                        UnitPrice = 40M,
                        Amount = 20,
                        Discount = 0f,
                        ProductId = 1,
                        Product = _Products[0]
                    },
                    new OrderDetail
                    {
                        OrderDetailsId = 2,
                        UnitPrice = 200M,
                        Amount = 20,
                        Discount = 0f,
                        ProductId = 2,
                        Product = _Products[1]
                    }
                };
            }
        }

        private void InitiateFakeData()
        {
            //
            // CONFIGURE OBJECT SET FOR QUERIES
            //


            //configure country
            CountriesGet = () => CreateCountryObjectSet();
            CreateSetOf1(() => CreateCountryObjectSet());

            //Configure Customers
            CustomersGet = () => CreateCustomerObjectSet();
            CreateSetOf1(() => CreateCustomerObjectSet());

            //configure Products
            ProductsGet = () => CreateProductObjectSet();
            CreateSetOf1(() => CreateProductObjectSet());

            //configure bank account
            BankAccountsGet = () => CreateBankAccountObjectSet();
            CreateSetOf1(() => CreateBankAccountObjectSet());

            //configure Bank Transfers
            BankTransfersGet = () => CreateBankTransferObjectSet();
            CreateSetOf1(() => CreateBankTransferObjectSet());

            //configure Orders
            OrdersGet = () => CreateOrderObjectSet();
            CreateSetOf1(() => CreateOrderObjectSet());

            //configure Order details
            OrderDetailsGet = () => CreateOrdersDetailObjectSet();
            CreateSetOf1(() => CreateOrdersDetailObjectSet());


            //
            //CONFIGURE APPLY CHANGES
            //
            RegisterChangesOf1M0<BankAccount>(
                ba
                    =>
                {
                    if (ba != null
                        &&
                        _BankAccounts != null)
                    {
                        int index = _BankAccounts.IndexOf(ba);
                        if (index != -1)
                            _BankAccounts[index] = ba;
                        else
                            _BankAccounts.Add(ba);
                    }
                }
                );
            RegisterChangesOf1M0<Customer>(
                c
                    =>
                {
                    if (c != null
                        &&
                        _Customers != null)
                    {
                        int index = _Customers.IndexOf(c);
                        if (index != -1)
                            _Customers[index] = c;
                        else
                            _Customers.Add(c);
                    }
                }
                );
            RegisterChangesOf1M0<Product>(
                p
                    =>
                {
                    if (p != null
                        &&
                        _Products != null)
                    {
                        int index = _Products.IndexOf(p);
                        if (index != -1)
                            _Products[index] = p;
                        else
                            _Products.Add(p);
                    }
                }
                );

            RegisterChangesOf1M0<Order>(
                o
                    =>
                {
                    if (o != null
                        &&
                        _Orders != null)
                    {
                        int index = _Orders.IndexOf(o);
                        if (index != -1)
                            _Orders[index] = o;
                        else
                            _Orders.Add(o);
                    }
                }
                );

            //Set Commit stub
            Commit = () => { };
            CommitAndRefreshChanges = () => { };
        }

        private IObjectSet<BankAccount> CreateBankAccountObjectSet()
        {
            return _BankAccounts.ToMemorySet();
        }

        private IObjectSet<BankTransfer> CreateBankTransferObjectSet()
        {
            return _BankTransfer.ToMemorySet();
        }

        private IObjectSet<Country> CreateCountryObjectSet()
        {
            return _Countries.ToMemorySet();
        }

        private IObjectSet<Product> CreateProductObjectSet()
        {
            return _Products.ToMemorySet();
        }

        private IObjectSet<Order> CreateOrderObjectSet()
        {
            return _Orders.ToMemorySet();
        }

        private IObjectSet<Customer> CreateCustomerObjectSet()
        {
            return _Customers.ToMemorySet();
        }

        private IObjectSet<OrderDetail> CreateOrdersDetailObjectSet()
        {
            return _OrdersDetails.ToMemorySet();
        }

        #endregion
    }
}