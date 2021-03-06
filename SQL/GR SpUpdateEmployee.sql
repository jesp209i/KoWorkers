USE [DB2017_C02]
GO

CREATE PROC SpUpdateEmployee
(
@EmployeeID AS int,
@FirstName AS char(100),
@LastName AS char(100)
)
As
BEGIN
UPDATE KOW_EMPLOYEE
SET 	FirstName = LTRIM(RTRIM(@FirstName)), LastName = LTRIM(RTRIM(@LastName))
WHERE	EmployeeID = @EmployeeID
END

