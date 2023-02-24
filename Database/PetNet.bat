ECHO off

sqlcmd -S localhost -E -i PetNet_db_am.sql


rem Add your sample data scripts to the bottom of this list
rem Follow this example (but without rem):
rem sqlcmd -S localhost -E -i SampleData\ASampleFeature_SD.sql
sqlcmd -S localhost -E -i SampleDataScripts\AddProcedure_SD.sql

sqlcmd -S localhost -E -i SampleDataScripts\AddAnimalUpdate_SD.sql



rem Add your stored procedure scripts to the bottom of this list
rem Follow this example (but without rem):
rem sqlcmd -S localhost -E -i StoredProcudures\ASampleFeature_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AddProcedure_SP.sql

sqlcmd -S localhost -E -i StoredProceduresScripts\EmployeeManagement_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AnimalPostUpdate_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewAdoptableAnimalProfile_SP.sql

ECHO .
ECHO if no errors appear DB was created
PAUSE