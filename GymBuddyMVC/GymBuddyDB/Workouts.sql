CREATE TABLE [dbo].[Workouts]
(
	ID INT PRIMARY KEY
 ,WorkoutID INT FOREIGN KEY REFERENCES Categories(WorkOutID)
 ,Name NVARCHAR(30)
 ,Reps INT
 ,[Weight] DECIMAL (5,2)
 ,[Sets] INT
)
