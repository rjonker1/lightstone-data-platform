CREATE SCHEMA [SqlBus] AUTHORIZATION [dbo]
GO
CREATE SCHEMA [MessageLog] AUTHORIZATION [dbo]
GO
CREATE SCHEMA [Events] AUTHORIZATION [dbo]
GO
CREATE SCHEMA [BlobStorage] AUTHORIZATION [dbo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MessageLog].[Messages](
	[Id] [uniqueidentifier] NOT NULL,
	[Kind] [nvarchar](max) NULL,
	[SourceId] [nvarchar](max) NULL,
	[AssemblyName] [nvarchar](max) NULL,
	[Namespace] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[TypeName] [nvarchar](max) NULL,
	[SourceType] [nvarchar](max) NULL,
	[CreationDate] [nvarchar](max) NULL,
	[Payload] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SqlBus].[Events](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[DeliveryDate] [datetime] NULL,
	[CorrelationId] [nvarchar](max) NULL,
 CONSTRAINT [PK_SqlBus.Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Events].[Events](
	[AggregateId] [uniqueidentifier] NOT NULL,
	[AggregateType] [nvarchar](128) NOT NULL,
	[Version] [int] NOT NULL,
	[Payload] [nvarchar](max) NULL,
	[CorrelationId] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AggregateId] ASC,
	[AggregateType] ASC,
	[Version] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SqlBus].[Commands](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[DeliveryDate] [datetime] NULL,
	[CorrelationId] [nvarchar](max) NULL,
 CONSTRAINT [PK_SqlBus.Commands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BlobStorage].[Blobs](
	[Id] [nvarchar](128) NOT NULL,
	[ContentType] [nvarchar](max) NULL,
	[Blob] [varbinary](max) NULL,
	[BlobString] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
