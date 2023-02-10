ECHO off

sqlcmd -S localhost -E -i PetNet_db_am.sql


rem Add your sample data scripts to the bottom of this list
rem Follow this example (but without rem):
rem sqlcmd -S localhost -E -i SampleData\MySampleFeature_SD.sql



rem Add your stored procedure scripts to the bottom of this list
rem Follow this example (but without rem):
rem sqlcmd -S localhost -E -i StoredProcudures\MySampleFeature_SP.sql



ECHO .
ECHO if no errors appear DB was created
PAUSE