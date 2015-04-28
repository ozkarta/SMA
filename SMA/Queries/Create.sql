USE master
IF EXISTS(select * from sys.databases where name='smaDataBase')
begin
	DROP DATABASE smaDataBase
end

go

CREATE DATABASE smaDataBase
go

use smaDataBase
go


----------------------------------------------------------------------------------


create  table  [languages]
(
	[languageGUID]					varchar(50) not null,
	[languageName]					Nvarchar(50) not null
)
go
create table [variables]
(
	[languageGUID]					varchar(50) not null,
	[variableGUID]					varchar(50) not null,
	[variableName]					Nvarchar(100) not null,
	[value]							Nvarchar(max) not null
)

go
