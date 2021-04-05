CREATE TABLE [dbo].[Customers]
(
	UserID INT PRIMARY KEY
 , [First Name] NVARCHAR(70)
 , [Last Name] NVARCHAR(70)
 , Age INT
 , Height DECIMAL (3,2)
 , [Weight] DECIMAL (5,2)
 , ProgramID INT NOT NULL UNIQUE
 , MAXLifts INT FOREIGN KEY REFERENCES MAXLifts(MAXLiftsID) 
)
