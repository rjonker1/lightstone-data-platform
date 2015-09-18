using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Common.Logging;
using Excel;
using Ionic.Zip;
using Lim.Domain.Base;
using Lim.Domain.Commands;
using Toolbox.Bmw.Dtos;
using System.Linq;
using Toolbox.Bmw.Extensions;

namespace Toolbox.Bmw.Factories
{
    public class ReadFinanceDataFileFactory : AbstractReadingFactory<ReadFile, IEnumerable<BmwFinanceDataDto>>
    {
        private readonly ILog _log = LogManager.GetLogger<ReadFinanceDataFileFactory>();

        public override IEnumerable<BmwFinanceDataDto> Read(ReadFile command)
        {
            try
            {
                using (var ms = new MemoryStream())
                using (var zip = ZipFile.Read(Path.Combine(command.File.FilePath, command.File.FileName)))
                {
                    var file = zip[0];
                    file.Password = command.File.Password;
                    file.Extract(ms);

                    var reader = ExcelReaderFactory.CreateOpenXmlReader(ms);
                    reader.IsFirstRowAsColumnNames = command.File.FirstRowIsColumnName;
                    var result = reader.AsDataSet();
                    return result.Tables[0].AsEnumerable().Select(s => new BmwFinanceDataDto(
                        s.GetString("Chassis"),
                        s.GetString("Engine"),
                        s.GetString("RegNumber"),
                        s.GetString("Description"),
                        s.GetInt("RegYear"),
                        s.GetString("Deal Type"),
                        s.GetString("DealStatus")));
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An Error occurred reading contents of the BMW Finance File {0}", ex, ex.Message);
            }

            return Enumerable.Empty<BmwFinanceDataDto>();
        }
    }
}