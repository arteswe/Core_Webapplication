--skapa en databas i minnet
drop table #dbtemp
Select * into #dbtemp from BloodpressureDBold.dbo.Bloodpressures
Select * from #dbtemp
--ta först bort alla poster i tabellen
--Delete from BloodpressureDB.dbo.Bloodpressures
--reset ID räknaren till 0+1
DBCC CHECKIDENT ('BloodpressureDB.dbo.Bloodpressures', RESEED, 100);
--kopiera från gamla tabellen i den nya
INSERT
INTO  BloodpressureDB.dbo.Bloodpressures
SELECT Systolic,Diastolic,Heartrate, Date,Time,Comment,Personnummer 
FROM    #dbtemp


