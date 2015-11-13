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
            get { return GetAppSetting("lim/schedule/bmw/filePath", @"D:\BMWFinSFTP\"); }
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
            get { return GetAppSetting("lim/schedule/bmw/backupFilePath", @"D:\BMWFin\Backups"); }
        }

        public string FailFilePath
        {
            get { return GetAppSetting("lim/schedule/bmw/failFilePath", @"D:\BMWFin\Failures"); }
        }

        public string FileExtension
        {
            get { return GetAppSetting("lim/schedule/bmw/fileExtensions", @"*.zip"); }
        }

        public string EmailTo
        {
            get { return GetAppSetting("lim/schedule/bmw/email/to", "rudi@customapp.co.za"); }
        }

        public string EmailFrom
        {
            get { return GetAppSetting("lim/schedule/bmw/email/from", "rudi@customapp.co.za"); }
        }

        public string EmailSubject
        {
            get { return GetAppSetting("lim/schedule/bmw/email/subject", "LS Auto Integration Notification: BMW Data File"); }
        }

        public string EmailCc
        {
            get { return GetAppSetting("lim/schedule/bmw/email/cc", "rudi@customapp.co.za"); }
        }

        public string EmailNotificationTemplate
        {
            get { return GetAppSetting("lim/schedule/bmw/email/notification/template", "<html><head><title></title></head><body><h1>Good Day, </h1><p>{0}</p><p></html>"); }
        }
    }
}