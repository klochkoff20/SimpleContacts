USE [SimpleContacts]
GO

INSERT INTO [dbo].[Vacancies]
           ([Id]
           ,[Name]
           ,[DepartmentId]
           ,[ProjectId]
           ,[Priority]
           ,[TargetDate]
           ,[EmploymentType]
           ,[Location]
           ,[SalaryMin]
           ,[SalaryMax]
           ,[RequiredExperience]
           ,[NumberOfPositions]
           ,[CreatedBy]
           ,[CreatedAt]
           ,[ResponsibleBy]
           ,[UpdatedBy]
           ,[UpdatedAt]
           ,[Description]
           ,[Responsibilities]
           ,[HardSkills]
           ,[OptionalHardSkills]
           ,[SoftSkills]
           ,[Status])
     VALUES
			('130bb81c-385d-42af-8702-3cb36a798923','Systems Administrator','3E8168FB-8A52-46E2-8F3D-24FF5F02D0BD','3884A15C-DAC2-46E9-B73C-36B03258EF8C',1,'9234-11-19 17:28:06Z',0,'Arlington',29490,735971,7,4,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4393-06-23 17:55:53Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','2397-07-12 12:57:01Z','Utilities','Teamwork','Time Management','Decision Making','Communication',5),
			('7b6fdf7f-57eb-4cb2-b558-d51ac966917f','Designer','3E8168FB-8A52-46E2-8F3D-24FF5F02D0BD','E3E53093-5527-476C-8894-725EA47A8904',1,'0897-08-17 16:14:54Z',4,'Fort Lauderdale',8901,65935,1,9,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','8588-11-04 12:52:06Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','1633-09-07 06:26:40Z','Energy','Conflict Resolution','Conflict Resolution','Time Management','Communication',4),
			('34747473-3297-47fa-97dc-d6f753b25812','Healthcare Specialist','78367B19-8D9D-495D-8E24-5E37B466D8CA','7B5CA816-E1D4-43D3-B8CA-CC4063E33694',2,'4025-09-13 08:18:32Z',4,'Jersey City',58709,0635,1,1,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','3547-02-27 00:03:49Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','3518-10-12 15:47:16Z','Telecom','Conflict Resolution','Leadership','Conflict Resolution','Communication',5),
			('afab1a33-e853-4413-a902-3383337ddc4d','Chef Manager','78367B19-8D9D-495D-8E24-5E37B466D8CA','1E64EEBB-6578-4568-B124-E858FB56FA2F',2,'3489-03-10 03:36:26Z',0,'Anaheim',84783,5320,4,5,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','7915-07-18 19:25:57Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','9297-06-07 14:31:21Z','Energy','Leadership','Teamwork','Self-motivation','Decision Making',1),
			('89410a81-60c6-4997-b3dc-f2bdc5db1017','Webmaster','CBADD9B4-83EB-4299-9EE2-733C4680C16F','8CA4FD94-7A71-494D-B859-75B0BDDA97D2',1,'9060-10-23 08:53:29Z',0,'Norfolk', 9879,11366,6, 25,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','9802-09-28 10:26:30Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4566-07-05 12:20:34Z','Telecom','Time Management','Teamwork','Time Management','Decision Making',1),
			('eae1747f-4864-422c-81d5-fcccb44252a5','Laboratory Technician','CBADD9B4-83EB-4299-9EE2-733C4680C16F','6F619C3A-BFD5-4218-A099-E3722F7C4D8B',0,'0739-07-05 12:25:27Z',2,'Worcester',2685,6590,6,1,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','7358-04-08 14:57:19Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4111-05-31 22:53:53Z','Financials','Teamwork','Conflict Resolution','Time Management','Time Management',0),
			('553c6d35-a8af-4c43-9971-880bf2571b0c','Treasurer','8659D832-2C53-44E5-86F2-B2DF01FD0555','4B7D2596-408E-42C8-9061-24450EB2188A',1,'9244-09-02 20:58:57Z',3,'Oklahoma City',9260,16142,9,3,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','6264-01-25 17:47:08Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','5332-11-09 00:09:25Z','Real Estate','Time Management','Time Management','Work Under Pressure','Self-motivation',3),
			('89c25f5c-cd29-409b-8ee0-43aab32ab71e','Ambulatory Nurse','8659D832-2C53-44E5-86F2-B2DF01FD0555','826C9BA5-8A0A-4667-ABD6-6A125FFA9C06',1,'0562-03-18 18:25:12Z',1,'Bellevue',3180,4029,9,9,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','2669-01-26 17:39:54Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4599-01-09 05:01:20Z','Consumer Discretionary','Learning','Leadership','Learning','Teamwork',1),
			('abd71452-1b19-42b8-929a-d238a353e231','Machine Operator','8CF57329-C9DF-4B1F-8881-D9CABB1CEEAE','85605AC7-7CB1-4EDA-8EE0-09C083E7419D',0,'1500-03-12 22:18:38Z',0,'Albuquerque',5621,8114,10,5,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','7786-07-04 17:27:00Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','0142-11-15 11:03:54Z','Real Estate','Learning','Teamwork','Decision Making','Work Under Pressure',0),
			('f4a64282-0741-4b54-ab6b-78d8b8f4fa99','Auditor','8CF57329-C9DF-4B1F-8881-D9CABB1CEEAE','9C97EE9D-973F-4308-BF98-25BE007EB43A',2,'2621-12-22 13:47:12Z',3,'Houston',2804,5243,5,40,'4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','5066-05-16 13:42:21Z','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','4e08b2a6-0a10-40e2-bc0a-406d3f53fb69','7313-03-29 08:09:34Z','Financials','Communication','Learning','Leadership','Adaptability',1);

GO


