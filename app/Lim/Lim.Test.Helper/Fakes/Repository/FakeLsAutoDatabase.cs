using System.Collections.Generic;
using Toolbox.LSAuto.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeLsAutoDatabase
    {
        public static List<DataSet> DataSetList = new List<DataSet>();
        public static List<DataField> DataFieldList = new List<DataField>();

        public static List<View> ViewList = new List<View>();
        public static List<ViewColumn>ViewColumnList = new List<ViewColumn>(); 
    }
}
