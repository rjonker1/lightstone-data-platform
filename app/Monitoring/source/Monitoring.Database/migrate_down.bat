"Migrate.exe"  /conn "Data Source=.;Initial Catalog=Monitoring;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;" /provider sqlserver2012 /assembly "Lightstone.DataPlatform.Monitoring.Database.dll" /verbose=true --task rollback