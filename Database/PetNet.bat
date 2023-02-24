ECHO off

sqlcmd -S localhost -E -i PetNet_db_am.sql


rem Add your sample data scripts to the bottom of this list
rem Follow this example (but without rem):
rem sqlcmd -S localhost -E -i SampleData\ASampleFeature_SD.sql
sqlcmd -S localhost -E -i SampleDataScripts\PetNet_db_sample_data.sql


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
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewKennel_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\RemoveKennels_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AddKennel_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewAllShelterAnimals_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\MedicalImages.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\InsertMedicalImage_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AnimalDOD513-514_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\sp_select_user_by_roleId_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\sp_select_schedule_by_date_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\sp_select_schedule_by_userId_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\sp_user_creation.sql

sqlcmd -S localhost -E -i StoredProceduresScripts\AddRole_to_User_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\RoleManagement_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewTicketList_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\EditProcedure_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\KenOccupancyUpdate-333_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\RemoveRole-006_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\EditTreatment_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AddVaccination_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\AddMedicalRecord_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewVaccinationByAnimalId_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewUsersByUsersId_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\EditVaccination_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewFundraisingCampaigns_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ReactivateAccount_SP.sql


sqlcmd -S localhost -E -i StoredProceduresScripts\Shelter_Stored_Procedures.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\ViewAdoptableAnimalProfile_SP.sql

sqlcmd -S localhost -E -i StoredProceduresScripts\AccountSettings_SP.sql
sqlcmd -S localhost -E -i StoredProceduresScripts\LogInUser_SP.sql
ECHO .
ECHO if no errors appear DB was created
PAUSE