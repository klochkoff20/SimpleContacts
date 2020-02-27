USE [SimpleContacts]
GO

INSERT INTO [dbo].[Departments]
           ([Id]
           ,[Name]
           ,[Location]
           ,[Email]
           ,[Phone]
           ,[Skype]
           ,[Status]
           ,[Description])
     VALUES	 ('78367b19-8d9d-495d-8e24-5e37b466d8ca','Marketing','Ontario','Gil_Collins2803@hourpy.biz','1-487-606-7761','Gerenuk',3,'The Good Soldier'),
			 ('8659d832-2c53-44e5-86f2-b2df01fd0555','Sales','Detroit','Celina_Harvey52@sveldo.biz','0-036-820-7225','Ibex',3,'Gargantua and Pantagruel'),
			 ('cbadd9b4-83eb-4299-9ee2-733c4680c16f','Management','Milano','Oliver_Clayton480@womeona.net','6-262-657-3277','Giant girdled lizard',3,'Hamlet'),
			 ('8cf57329-c9df-4b1f-8881-d9cabb1ceeae','Operations','Lincoln','Jenna_Rose6498@yahoo.com','5-457-073-3358','squid',2,'Great Expectations'),
			 ('3e8168fb-8a52-46e2-8f3d-24ff5f02d0bd','IT','Berna','Vanessa_Price2676@kideod.biz','0-376-865-7370','Eastern fox squirrel',2,'The Canterbury Tales');
GO


