CREATE TABLE [dbo].[WorkOutProgram]
(
	ProgramID INT PRIMARY KEY
 ,Title NVARCHAR(80)
 ,[Description] NVARCHAR(90)
 ,CategoryID INT FOREIGN KEY REFERENCES Categories(ID)
 ,Days DATE
)
