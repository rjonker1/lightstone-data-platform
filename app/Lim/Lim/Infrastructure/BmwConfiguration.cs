namespace Lim.Infrastructure
{
    public class BmwConfiguration : AbstractConfigurationReader
    {
        public string ConnectionString
        {
            get
            {
                return GetConnectionString("lim/schedule/bmw/database",
                    "Data Source=.;Initial Catalog=Lim.BMW;Integrated Security=True;MultipleActiveResultSets=true;");
            }
        }

        public bool UpdateDatabase
        {
            get
            {
                return bool.Parse(GetAppSetting("lim/schedule/bmw/database/doUpdate",
                    "true"));
            }
        }

        public string FilePath
        {
            get { return GetAppSetting("lim/schedule/bmw/filePath", @"C:\11-Lightstone\Ftp\Bmw\"); }
        }

        public string FileName
        {
            get { return GetAppSetting("lim/schedule/bmw/fileName", @"BMWFin_{0}.zip"); }
        }

        public string FilePassword
        {
            get { return GetAppSetting("lim/schedule/bmw/filePassword", @"j5}o'0',w8U'>~,7~(~p"); }
        }

        public bool FirstRowIsColumnName
        {
            get
            {
                return bool.Parse(GetAppSetting("lim/schedule/bmw/database/firstRowIsColumnName",
                    "true"));
            }
        }

        public string BackupFilePath
        {
            get { return GetAppSetting("lim/schedule/bmw/backupFilePath", @"C:\11-Lightstone\BmwBackups"); }
        }

        public string FileExtension
        {
            get { return GetAppSetting("lim/schedule/bmw/fileExtensions", @"*.zip"); }
        }
    }
}