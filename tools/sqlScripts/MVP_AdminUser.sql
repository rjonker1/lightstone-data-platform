USE [UserManagement]
GO

USE [UserManagement]
GO

INSERT INTO [dbo].[User]
           ([Id]
           ,[FirstName]
           ,[LastName]
           ,[IdNumber]
           ,[ContactNumber]
           ,[UserName]
           ,[Password]
           ,[Salt]
           ,[IsActive]
           ,[Modified]
           ,[ModifiedBy]
           ,[Created]
           ,[CreatedBy]
           ,[UserType])
     VALUES
           ('d368acdf-9edb-40d4-bdb4-774c32f883aa'
           ,'Murray'
           ,'Woolfson'
           ,''
           ,''
           ,'murrayw@lightstone.co.za'
           ,'Oyn770NdNyL/cEpnRBjyNCkMP2qH+OKOR1ahR4Jq6oQ='
           ,'vS2u/g=='
           ,1
           ,'2015-01-01'
           ,'ALLISTAIREPC\User'
           ,'2015-01-01'
           ,'ALLISTAIREPC\User'
           ,'Internal')
GO

/*INSERT INTO [UserRole] ([UserId], [RoleId]) VALUES ('d368acdf-9edb-40d4-bdb4-774c32f883aa','9DAE22D1-D010-4350-B480-DCF95A29E85C')*/