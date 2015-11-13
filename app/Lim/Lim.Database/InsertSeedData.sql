SET IDENTITY_INSERT [dbo].[ActionType] ON
INSERT INTO [dbo].[ActionType] ([Id], [Type], [IsActive]) VALUES (1, N'Push', 1)
INSERT INTO [dbo].[ActionType] ([Id], [Type], [IsActive]) VALUES (2, N'Pull', 1)
SET IDENTITY_INSERT [dbo].[ActionType] OFF


SET IDENTITY_INSERT [dbo].[Weekdays] ON
INSERT INTO [dbo].[Weekdays] ([Id], [Day]) VALUES (1, N'Sunday')
INSERT INTO [dbo].[Weekdays] ([Id], [Day]) VALUES (2, N'Monday')
INSERT INTO [dbo].[Weekdays] ([Id], [Day]) VALUES (3, N'Tuesday')
INSERT INTO [dbo].[Weekdays] ([Id], [Day]) VALUES (4, N'Wednesday')
INSERT INTO [dbo].[Weekdays] ([Id], [Day]) VALUES (5, N'Thursday')
INSERT INTO [dbo].[Weekdays] ([Id], [Day]) VALUES (6, N'Friday')
INSERT INTO [dbo].[Weekdays] ([Id], [Day]) VALUES (7, N'Saturday')
SET IDENTITY_INSERT [dbo].[Weekdays] OFF


SET IDENTITY_INSERT [dbo].[AuthenticationType] ON
INSERT INTO [dbo].[AuthenticationType] ([Id], [Type], [IsActive]) VALUES (1, N'None', 1)
INSERT INTO [dbo].[AuthenticationType] ([Id], [Type], [IsActive]) VALUES (2, N'Basic', 1)
INSERT INTO [dbo].[AuthenticationType] ([Id], [Type], [IsActive]) VALUES (3, N'Stateless', 1)
SET IDENTITY_INSERT [dbo].[AuthenticationType] OFF

SET IDENTITY_INSERT [dbo].[FrequencyType] ON
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (1, N'EveryMinute', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (2, N'Hourly', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (3, N'Daily', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (4, N'Custom', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (5, N'Always On', 1)
SET IDENTITY_INSERT [dbo].[FrequencyType] OFF

SET IDENTITY_INSERT [dbo].[IntegrationType] ON
INSERT INTO [dbo].[IntegrationType] ([Id], [Type], [IsActive]) VALUES (1, N'API', 1)
INSERT INTO [dbo].[IntegrationType] ([Id], [Type], [IsActive]) VALUES (2, N'Email', 1)
INSERT INTO [dbo].[IntegrationType] ([Id], [Type], [IsActive]) VALUES (3, N'FlatFile', 1)
INSERT INTO [dbo].[IntegrationType] ([Id], [Type], [IsActive]) VALUES (4, N'Notification', 1)
SET IDENTITY_INSERT [dbo].[IntegrationType] OFF
