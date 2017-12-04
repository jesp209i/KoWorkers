use DB2017_C02
go
CREATE PROC SpNewEmployee
(
	@LastName AS Nvarchar(100),
	@FirstName AS Nvarchar(100)
)
As
BEGIN
insert into KOW_EMPLOYEE
(LastName, FirstName)
VALUES (@LastName, @FirstName)
END