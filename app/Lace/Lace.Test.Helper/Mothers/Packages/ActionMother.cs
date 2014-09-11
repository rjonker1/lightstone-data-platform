using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;
using Action = PackageBuilder.Domain.Entities.Action;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class ActionMother
    {
        public static IAction LicensePlateSearchAction
        {
            get
            {
                return new ActionBuilder()
                            .With("License plate search")
                            .With(DataFieldMother.LicenseField)
                            .Build();
            }
        }
    }


    public class ActionBuilder
    {
        private string _name = "";
        private readonly Criteria _criteria = new Criteria();
        public IAction Build()
        {
            return new Action(_name)
            {
                Criteria = _criteria
            };
        }

        public ActionBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public ActionBuilder With(params IDataField[] fields)
        {
            _criteria.Fields = fields;
            return this;
        }
    }

    public class DataFieldBuilder
    {
        private string _name;
        private IDataProvider _dataProvider;
        public IDataField Build()
        {
            return new DataField(_name) { DataProvider = _dataProvider };
        }

        public DataFieldBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public DataFieldBuilder With(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            return this;
        }
    }

    public class DataFieldMother
    {
        public static IDataField ColourField
        {
            get
            {
                return new DataFieldBuilder().With("Colour").With(DataSourceMother.RgtVinSource).Build();
            }
        }
        public static IDataField LicenseField
        {
            get
            {
                return new DataFieldBuilder().With("LicenceNo").With(DataSourceMother.IvidDataSource).Build();
            }
        }
        public static IDataField BankNameField
        {
            get
            {
                return new DataFieldBuilder().With("BankName").With(DataSourceMother.IvidTitleHolderDataSource).Build();
            }
        }
        public static IDataField AccidentClaimsField
        {
            get
            {
                return new DataFieldBuilder().With("AccidentClaims").With(DataSourceMother.AudatexSource).Build();
            }
        }
    }

    public class DataSourceBuilder
    {
        private Guid _id;
        private string _name;
        public IDataProvider Build()
        {
            return new DataProvider(_id, _name);
        }

        public DataSourceBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public DataSourceBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }

    public class DataSourceMother
    {
        public static IDataProvider IvidDataSource
        {
            get
            {
                return new DataSourceBuilder().With("Ivid").With(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A")).Build();
            }
        }

        public static IDataProvider IvidTitleHolderDataSource
        {
            get
            {
                return new DataSourceBuilder().With("IvidTitleHolder").With(new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B")).Build();
            }
        }

        public static IDataProvider RgtVinSource
        {
            get
            {
                return new DataSourceBuilder().With("RgtVin").With(new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D")).Build();
            }
        }

        public static IDataProvider AudatexSource
        {
            get
            {
                return new DataSourceBuilder().With("Audatex").With(new Guid("18F5D1F8-0187-4EB2-A554-0F6E963F1E51")).Build();
            }
        }

        public static IDataProvider LightstoneDataSource
        {
            get
            {
                return new DataSourceBuilder().With("Lightstone").With(new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A")).Build();
            }
        }
    }
}
