use smaDataBase
go

insert into languages(languageGUID,languageName)
values(newid(),N'English'),(newid(),N'ქართული'),(newid(),N'русский')

insert into variables(languageGUID,variableGUID,variableName,value)

values  ('90086DAF-2AC8-40A6-ACD1-C42A8E4F2FBA',newid(),'@home','Home'),
		('90086DAF-2AC8-40A6-ACD1-C42A8E4F2FBA',newid(),'@about','About'),
		('90086DAF-2AC8-40A6-ACD1-C42A8E4F2FBA',newid(),'@contact','Contact'),
		('96C0850F-C7A3-433E-A514-DFD92E963B59',newid(),'@home','სახლი'),
		('96C0850F-C7A3-433E-A514-DFD92E963B59',newid(),'@about','ჩვენს შესახებ'),
		('96C0850F-C7A3-433E-A514-DFD92E963B59',newid(),'@contact','საკონტაქტო ინფორმაცია')
go