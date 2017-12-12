/*
Getting Real projekt
vinter 2017
EAL 1. sem. Datamatiker
Andreas, Lars, Jesper (og Eirikur)
Sprint2 UseCases: "Tjek ind" og "Tjek ud"
*/

Use DB2017_C02;

Create table KOW_EMPLOYEE(
	EmployeeID		int				not null unique identity(1,1),
	FirstName		NvarChar(100)	not null,
	LastName		NvarChar(100)	not null,
	Pin				int				not null,
	TelephoneNo		int				not null
	Constraint EMPLOYEE_PK primary key (EmployeeID)
);

Create table KOW_TIMESHEET(
	TimeSheetID		int				not null unique identity(1,1),
	EmployeeID		int				not null,
	TimeSheetYear	int				not null,
	TimeSheetMonth	int				not null,
	Constraint TIMESHEET_PK primary key (TimeSheetID),
	Constraint TIMESHEET_EMPLOYEE_FK foreign key (EmployeeID)
	References KOW_EMPLOYEE(EmployeeID)
);

Create table KOW_SHIFT(
	ShiftID 		int				not null unique identity(1,1),
	TimeSheetID		int				not null,
	ShiftDate		date			not null,
	StartTime		time			not null,
	EndTime			time			not null,
	Constraint SHIFT_PK primary key (ShiftID),
	Constraint SHIFT_TIMESHEET_FK foreign key (TimeSheetID)
	References KOW_TIMESHEET(TimeSheetID)
);