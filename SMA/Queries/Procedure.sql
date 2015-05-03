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