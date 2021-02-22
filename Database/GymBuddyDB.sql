--
--DROP DATABASE IF EXISTS GymBuddyDB
--CREATE DATABASE GymBuddyDB

--USE GymBuddyDB

DROP TABLE IF EXISTS Categories
CREATE TABLE Categories
( 
  ID INT Primary KEY
  , Title NVARCHAR (30)
  , WorkOutID INT NOT NULL UNIQUE 
)



DROP TABLE IF EXISTS Workouts
CREATE TABLE Workouts
(
 ID INT PRIMARY KEY
 ,WorkoutID INT FOREIGN KEY REFERENCES Categories(WorkOutID)
 ,Name NVARCHAR(30)
 ,Reps INT
 ,[Weight] DECIMAL (5,2)
 ,[Sets] INT
)

DROP TABLE IF EXISTS MAXLifts
CREATE TABLE MAXLifts
( 
 MAXLiftsID INT PRIMARY KEY
 , MaxBench DECIMAL (5,2)
 , MaxSquat DECIMAL (5,2)
 , MaxDeadLift DECIMAL (5,2)
 , WorkoutID INT FOREIGN KEY REFERENCES Workouts(ID)
)

DROP TABLE IF EXISTS Customers
CREATE TABLE Customers
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



DROP TABLE IF EXISTS Program
CREATE TABLE Program
(
 ProgramID INT FOREIGN KEY REFERENCES Customers(ProgramID)
 ,Title NVARCHAR(80)
 ,[Description] NVARCHAR(90)
 ,CategoryID INT FOREIGN KEY REFERENCES Categories(ID)
 ,Days DATE
)

