IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'NT AUTHORITY\NETWORK SERVICE')
CREATE LOGIN [NT AUTHORITY\NETWORK SERVICE] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'NT AUTHORITY\NETWORK SERVICE')
BEGIN
    CREATE USER [NT AUTHORITY\NETWORK SERVICE] FOR LOGIN [NT AUTHORITY\NETWORK SERVICE] WITH DEFAULT_SCHEMA=[dbo]
    EXEC sp_addrolemember N'db_datawriter', N'NT AUTHORITY\NETWORK SERVICE'
    EXEC sp_addrolemember N'db_datareader', N'NT AUTHORITY\NETWORK SERVICE'
    EXEC sp_addrolemember N'db_ddladmin', N'NT AUTHORITY\NETWORK SERVICE'
END
GO

