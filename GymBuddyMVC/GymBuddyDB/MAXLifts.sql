CREATE TABLE [dbo].[MAXLifts]
(
	 MAXLiftsID INT PRIMARY KEY
 , MaxBench DECIMAL (5,2)
 , MaxSquat DECIMAL (5,2)
 , MaxDeadLift DECIMAL (5,2)
 , WorkoutID INT FOREIGN KEY REFERENCES Workouts(ID)
)
