USE [DB2017_C02]
GO

CREATE PROC SpRemoveEmployee
(
@EmployeeID AS int,
@FirstName AS char(100),
@LastName AS char(100)
)
As
BEGIN
DELETE 
FROM KOW_EMPLOYEE
WHERE 	
	FirstName = @FirstName AND
	LastName = @LastName AND 
	EmployeeID = @EmployeeID
END

