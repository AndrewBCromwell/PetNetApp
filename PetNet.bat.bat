ECHO off

sqlcmd -S localhost -E -i PetNet_db_am.sql
sqlcmd -S localhost -E -i PetNet_db_Sample_data.sql
sqlcmd -S localhost -E -i PetNet_db_StoredProcedures.sql

rem server is localhost

ECHO .
ECHO if no errors appear DB was created
PAUSE