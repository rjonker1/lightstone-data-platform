"Migrate.exe"  /conn "Data Source=.;Initial Catalog=Billing;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;" /provider sqlserver2012 /assembly "Lightstone.DataPlatform.Workflow.Billing.Database.dll" /verbose=true --task migrate