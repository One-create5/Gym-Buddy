CREATE TABLE [dbo].[Categories]
(
	ID INT Primary KEY
  , Title NVARCHAR (30)
  , WorkOutID INT NOT NULL UNIQUE 
)
