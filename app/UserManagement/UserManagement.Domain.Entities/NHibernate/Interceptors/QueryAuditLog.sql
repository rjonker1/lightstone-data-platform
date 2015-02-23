use UserManagement
Go
SELECT * FROM [dbo].[AuditLog] ORDER BY[RecordId],[EntityName], [EventDateUtc], [CommitSequence], [CommitVersion],  [FieldName], [OriginalValue], [NewValue]