--skapa en databas i minnet
drop table #dbtemp
Select * into #dbtemp from BloodpressureDBold.dbo.Bloodpressures
Select * from #dbtemp
--ta f�rst bort alla poster i tabellen
--Delete from BloodpressureDB.dbo.Bloodpressures
--reset ID r�knaren till 0+1
DBCC CHECKIDENT ('BloodpressureDB.dbo.Bloodpressures', RESEED, 100);
--kopiera fr�n gamla tabellen i den nya
INSERT
INTO  BloodpressureDB.dbo.Bloodpressures
SELECT Systolic,Diastolic,Heartrate, Date,Time,Comment,Personnummer 
FROM    #dbtemp


