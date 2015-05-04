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
create table [accessLevels]
(
	[levelGUID]						varchar(50) not null,
	[level]							int not null,
	[levelName]						varchar(50)
)
go
CREATE TABLE [usersGeneral] 
(
	[LanguageGUID]					varchar(50) not null,						--  As  Default Language  
	[userGUID]                      VARCHAR (50)   NOT NULL default newid(),
	---------------------Autorization
    
    [email]							NVARCHAR (256) not NULL,
    [emailConfirmed]				BIT            NOT NULL default 0,
    [passwordHash]					NVARCHAR (MAX) not NULL,
    [salt]					NVARCHAR (MAX) not NULL,
    [phoneNumber]					NVARCHAR (MAX) not NULL,
    [phoneNumberConfirmed]			BIT            NOT NULL DEFAULT 0,
    [accessFailedCount]				INT            NOT NULL default 0,
    [userName]						NVARCHAR (256) NOT NULL,
	
	---------------------General Info
	[firstName]							Nvarchar(500) not null,
	[lastName]							Nvarchar(1000) not null,	
	[country]							nvarchar(100) not null,
	[city]								nvarchar(100) not null,
	[addressLine1]						nvarchar(1000) not null,
	[addressLine2]						nvarchar(1000) not null,
	
	

	[birthDate]							datetime not null,
	[passportID]						nvarchar(20) not null,


	--------------------Auto  Generated
	[registerDate]						datetime  default getdate(),

);

go 
create table countriesIso
(
	[countryGUID]				varchar(50) not null,
	[Comman Name]				varchar(500) not null,
	[Formal Name]				varchar(500) not null,
	[Type]						varchar(500) not null,
	[Capital]					varchar(500) not null,
	[ISO 4217 Currency Code]	varchar(500) not null,
	[ISO 4217 Currency Name]	varchar(500) not null,
	[ITU-T Telephone Code]		varchar(100) not null,
	[ISO 3166-12 Letter Code]   varchar(100) not null,
	[ISO 3166-13 Letter Code]	varchar(100) not null,
	[IANA Country Code TLD]		varchar(100) not null
)


GO
