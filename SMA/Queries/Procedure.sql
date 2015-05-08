use smaDataBase

go

DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += N'DROP PROCEDURE dbo.'
  + QUOTENAME(name) + ';
' FROM sys.procedures
WHERE name LIKE N'%'
AND SCHEMA_NAME(schema_id) = N'dbo';

EXEC sp_executesql @sql;
go

-------------------------------------------------------------------------------------------------------------
create procedure  getLanguageList
as
begin 
	select * from languages
end
go

------------------------------------------

create procedure  getTranslatedVariableValue

@languageGUID  varchar(50),
@variableName  varchar(100)
as
begin
	select value from variables where variables.languageGUID=@languageGUID and variables.variableName=@variableName
end

go

--------------------------------------------------------------

create procedure userNameValidation
@userName  varchar(100)
as 

begin
	if exists(select [userName] from usersGeneral where [userName]=@userName)
		select '-1'
	else  select '1'
end

go
-------------------------------------------------------------
create procedure mailValidation
@mail varchar(100)
as 

begin
	if exists(select [email] from usersGeneral where [email]=@mail)
		select '-1'
	else  select '1'
end

go
-------------------------------------------------

create procedure registerUser
@defaultLanguage nvarchar(100),
@userName nvarchar(500),
@firstName nvarchar(500),
@lastName nvarchar(500),
@phone varchar(100),
@email varchar(500),
@passwordHash varchar(max),
@salt varchar(max)
as
begin
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
	insert into usersGeneral ([languageGUID],[userGUID],[email],[emailConfirmed],[passwordHash],[salt], [phoneNumber],	[phoneNumberConfirmed]	, [accessFailedCount], [userName],[firstName],	
	[lastName],[country],[city]	,[addressLine1]	,[addressLine2],[birthDate],[passportID],[registerDate]	)
	values(@defaultLanguage,newid(),@email,0,@passwordHash,@salt,@phone,0,0,@userName,@firstName,@lastName,'','','','','','',getdate())
end

go

----------------------------------
=======

declare @userGUID varchar(50)
set @userGUID=newid()
	insert into usersGeneral ([languageGUID],[userGUID],[email],[emailConfirmed],[passwordHash],[salt], [phoneNumber],	[phoneNumberConfirmed]	, [accessFailedCount], [userName],[firstName],
	[lastName],[country],[city]	,[addressLine1]	,[addressLine2]	,[birthDate],[passportID],[registerDate]	)
	values(@defaultLanguage,@userGUID,@email,0,@passwordHash,@salt,@phone,0,0,@userName,@firstName,@lastName,'','','','','','','')
	select @userGUID;
end
go


------------------------------------------------------


create procedure activateUser
@userGUID varchar(50)
as
begin
	update  usersGeneral
		set	emailConfirmed=1	where userGUID=@userGUID
			
end
go
------------------------------------------------
>>>>>>> origin/master
=======
	insert into usersGeneral ([languageGUID],[userGUID],[email],[emailConfirmed],[passwordHash],[salt], [phoneNumber],	[phoneNumberConfirmed]	, [accessFailedCount], [userName],[firstName],							Nvarchar(500) not null,
	[lastName],[country],[city]	,[addressLine1]	,[addressLine2]	[birthDate],[passportID],[registerDate]	)
	values(@defaultLanguage,newid(),@email,0,@passwordHash,@salt,@phone,0,0,@userName,@firstName,@lastName,'','','','','','','')
end
>>>>>>> origin/master
=======
	insert into usersGeneral ([languageGUID],[userGUID],[email],[emailConfirmed],[passwordHash],[salt], [phoneNumber],	[phoneNumberConfirmed]	, [accessFailedCount], [userName],[firstName],							Nvarchar(500) not null,
	[lastName],[country],[city]	,[addressLine1]	,[addressLine2]	[birthDate],[passportID],[registerDate]	)
	values(@defaultLanguage,newid(),@email,0,@passwordHash,@salt,@phone,0,0,@userName,@firstName,@lastName,'','','','','','','')
end
>>>>>>> parent of 15be318... 9:38_5.6.2015
