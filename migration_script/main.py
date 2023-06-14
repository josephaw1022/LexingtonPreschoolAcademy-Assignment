import uuid 
from os import system as terminal


#* This will write the ef core cli commands to migrate the database

def migrate_db():
    terminal("dotnet ef migrations add " + str(uuid.uuid4()) + " --project LexingtonPreschoolAcademy-API")
    terminal("dotnet ef database update --project LexingtonPreschoolAcademy-API")