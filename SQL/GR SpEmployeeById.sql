USE [DB2017_C02]
GO


CREATE PROC SpEmployeeById
(
@EmployeeId AS int
)
As
BEGIN
SELECT
	*
FROM
	KOW_EMPLOYEE
WHERE
	EmployeeID = @EmployeeId
END

