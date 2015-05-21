SET IDENTITY_INSERT [dbo].[FrequencyType] ON
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (1, N'EveryMinute', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (2, N'Hourly', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (3, N'Daily', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (4, N'Custom', 1)
INSERT INTO [dbo].[FrequencyType] ([Id], [Type], [IsActive]) VALUES (5, N'Always On', 1)
SET IDENTITY_INSERT [dbo].[FrequencyType] OFF