﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class DataSet : IDataSet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataField> DataFields { get; set; }
    }
}