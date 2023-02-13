ECHO off

sqlcmd -S localhost -E -i PetNet_db_am.sql


rem Add your sample data scripts to the bottom of this list
rem Follow this example (but without rem):
rem sqlcmd -S localhost -E -i SampleData\ASampleFeature_SD.sql
sqlcmd -S localhost -E -i SampleDataScripts\AddProcedure_SD.sql

sqlcmd -S localhost -E -i SampleDataScripts\AddAnimalUpdate_SD.sql
sqlcmd -S localhost -E -i SampleDataScripts\ViewMedicalTests_SD.sql

sqlcmd -S localhost -E -i SampleDataScripts\AnimalProfile_SD.sql


rem Add your stored procedure scripts to the bottom of this list
rem Follow this example (but without rem):
rem sqlcmd -S localhost -E -i StoredProcedures\MySampleFeature_SP.sql
rem sqlcmd -S localhost -E -i StoredProcedures\ASampleFeature_SP.sql


sqlcmd -S localhost -E -i StoredProceduresScripts\AddProcedure_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AnimalProfile_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\EmployeeManagement_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AnimalPostUpdate_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\MedicalProfile_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AddAnimal_to_kennel_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewMedicalTests_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewMedicalAnimals_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewTreatment_SP.sql
ECHO .
ECHO if no errors appear DB was created
PAUSE