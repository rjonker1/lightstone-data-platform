"Migrate.exe"  /conn "Data Source=.;Initial Catalog=DataProvider;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;" /provider sqlserver2012 /assembly "Lightstone.DataPlatform.Workflow.Lace.Database.dll" /verbose=true --tag DataProvider --task rollback 