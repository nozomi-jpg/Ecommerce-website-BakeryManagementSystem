/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ID]
      ,[Name]
      ,[Sex]
      ,[Address]
      ,[PhoneNumber]
      ,[Username]
      ,[Password]
  FROM [cakezilla_crud].[dbo].[User_Accounts]

  truncate table [dbo].[User_Accounts]