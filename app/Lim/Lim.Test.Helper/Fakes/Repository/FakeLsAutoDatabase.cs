using System.Collections.Generic;
using Toolbox.LSAuto.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeLsAutoDatabase
    {
        public static List<DatabaseExtract> DataSetList = new List<DatabaseExtract>();
        public static List<DatabaseExtractField> DataFieldList = new List<DatabaseExtractField>();

        public static List<DatabaseView> ViewList = new List<DatabaseView>();
        public static List<DatabaseViewColumn>ViewColumnList = new List<DatabaseViewColumn>(); 
    }
}
