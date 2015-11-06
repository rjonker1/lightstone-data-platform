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
using Lim.Domain.Extensions;
using Toolbox.Bmw.Extensions;

namespace Toolbox.Bmw.Factories
{
    public class ReadFinanceDataFileFactory : AbstractReadingFactory<ReadFile, IEnumerable<BmwFinanceDataDto>>
    {
        private static readonly ILog Log = LogManager.GetLogger<ReadFinanceDataFileFactory>();

        public override IEnumerable<BmwFinanceDataDto> Read(ReadFile command)
        {
            try
            {
                WaitForFile(Path.Combine(command.File.FilePath, command.File.FileName));

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
                        s.GetString("DealStatus"),
                        s.GetString("Finance House"),
                        s.GetString("Dealref"),
                        s.GetDate("Startdate"),
                        s.GetDate("ExpireDate"),
                        s.GetString("ClientNo")));
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An Error occurred reading contents of the BMW Finance File {0}", ex, ex.Message);
            }

            return Enumerable.Empty<BmwFinanceDataDto>();
        }

        private static void WaitForFile(string fileName)
        {
            var fileIsReady = false;
            RepeatAction.While(() => !fileIsReady)
                .RetryAfter(10.Seconds())
                .UpTo(50.Times())
                .Do(() =>
                {
                    try
                    {
                        using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            Log.InfoFormat("Finance Data File {0} ready.", fileName);
                            stream.Dispose();
                            fileIsReady = true;
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        Log.ErrorFormat("Finance Data File {0} not yet ready ({1})", fileName, ex.Message);
                        fileIsReady = false;
                    }
                    catch (IOException ex)
                    {
                        Log.ErrorFormat("Finance Data File {0} not yet ready ({1})", fileName, ex.Message);
                        fileIsReady = false;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Log.ErrorFormat("Finance Data File {0} not yet ready ({1})", fileName, ex.Message);
                        fileIsReady = false;
                    }
                });

             if (!fileIsReady)
                    throw new Exception(string.Format("Attempted to access file {0} {1} times with no success", fileName, 50));
        }
    }
}