SET IDENTITY_INSERT [dbo].[AuthenticationType] ON
INSERT INTO [dbo].[AuthenticationType] ([Id], [Type], [IsActive]) VALUES (1, N'None', 1)
INSERT INTO [dbo].[AuthenticationType] ([Id], [Type], [IsActive]) VALUES (2, N'Basic', 1)
INSERT INTO [dbo].[AuthenticationType] ([Id], [Type], [IsActive]) VALUES (3, N'Stateless', 1)
SET IDENTITY_INSERT [dbo].[AuthenticationType] OFF