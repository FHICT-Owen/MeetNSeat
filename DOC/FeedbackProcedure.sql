-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Anas Moahamad>
-- Create Date: <28/24/2021>
-- Description: <CRUD Feedback>
-- =============================================
CREATE PROCEDURE GetAllFeedback
AS
SELECT * FROM Feedback;
GO

CREATE PROCEDURE GetFeedbackByID @ID int
AS
Select * From Feedback Where FeedbackID = @ID;
GO

CREATE PROCEDURE InsertFeedback @Description varchar(MAX), @FeedbackState int
AS
INSERT INTO Feedback (Discription, FeedbackState) Values (@Description, @FeedbackState);
GO

CREATE PROCEDURE UpdateFeedback @ID int, @Description varchar(MAX), @FeedbackState int
AS
Update Feedback SET Discription = @Description, FeedbackState = @FeedbackState where FeedbackID = @ID;
GO

CREATE PROCEDURE DeleteFeedback @ID int
AS
Delete FROM Feedback where FeedbackID = @ID;
GO

