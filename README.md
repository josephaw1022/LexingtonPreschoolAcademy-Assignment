# Methodology

- First we need to set up infrastructure for the app. Yes this is boring and tedious, but it's by far the most important step of this process.
- We wil be using docker containers and docker compose to run and orchestrate our infrastructure locally
- Plan is to create the db and have that working with a docker container
- then connect to it with azure data studio. This is more of a sanity check to ensure the procedures and tables are actually present on the db.
- Scaffold and test the web-api and get it working locally.
- Then containerize the web-api using the dotnet-7 new container creation functionality (this basically will make your docker image and ensure its configured properly without having to touch docker).
- Then create a container from the web api image
- Then start developing the ui locally
- Then create the docker image for it
- Finally create a docker compose file for the entire project, so that if someone downloads this repo, all they need to do is run

```bash
docker compose up -d
```

# Prerequisite

- have dotnet installed (at least the newest lts-6 or 7 which isnt lts, dont do a preview version)

# Set up Directory and Infrastructure for App

go into documents and run

```bash
mkdir LexingtonPreschoolAcademy
cd LexingtonPreschoolAcademy
mkdir docker
cd docker
touch docker-compose.yaml
```

- Copy the following content into the docker compose file

```docker-compose
version: '3.7'

services:
 portainer:
   image: portainer/portainer-ce:latest
   container_name: portainer
   restart: unless-stopped

   privileged: true
   security_opt:
     - no-new-privileges:true
   volumes:
     - /etc/localtime:/etc/localtime:ro
     - /var/run/docker.sock:/var/run/docker.sock:ro
     - portainer-data:/data
   ports:
     - 9445:9443
     - 8010:8000

volumes:
 portainer-data:

docker compose file
```

- then simply run docker compose up -d

- go to https://localhost:9445 and set up your account for portainer

- Once all set up with the password and username (btw default username for portainer is "admin"), you should see a screen that looks just like this or something similar

![Screenshot from 2023-06-07 13-53-54](https://user-images.githubusercontent.com/47674962/244155757-3ed81d6d-ccc6-463d-8728-1caaadf4ad17.png)

- click on local and then go to app templates

![Screenshot from 2023-06-07 13-48-12](https://user-images.githubusercontent.com/47674962/244155315-9c12882a-b733-4fd1-959a-867bfbc6b54f.png)

- create a sql server db via portainer ui
  - one note is that you should definitely go into advanced settings and set the host map port to 1433, otherwise everytime the container restarts, the host port will change meaning you wont be able to connect to it reliably.

![Screenshot from 2023-06-07 13-59-23](https://user-images.githubusercontent.com/47674962/244156703-398f6462-51aa-4bf6-b116-4c4eaf2bf3d3.png)

- Obviously the sa_password will need to be set. (make sure that its a strong enough sql server password, otherwise portainer will run the container anyway and it wont work when you try to connect to it)

- install azure data studio [Azure Data Studio](https://azure.microsoft.com/en-us/products/data-studio)
- If installed correctly, then it should look something like this

![Screenshot from 2023-06-07 14-00-21](https://user-images.githubusercontent.com/47674962/244157105-1e5bc6f5-d695-40dd-8f69-324a55d7199f.png)

- connect to db
- host - 0.0.0.0
- port - 1443
- password - whatever you set it to be
- secure - no

- once connected I ran the following query on the master db

```sql

USE master;
GO

IF NOT EXISTS (
      SELECT name
      FROM sys.databases
      WHERE name = N'LexingtonPreschoolAcademy'
      )
   CREATE DATABASE [LexingtonPreschoolAcademy];
GO

IF SERVERPROPERTY('ProductVersion') > '12'
   ALTER DATABASE [LexingtonPreschoolAcademy] SET QUERY_STORE = ON;
GO
```

# Setting up the application project

Then go to the documents page and run the following commands

```bash

# Only run the following two commands if you haven't created the directory already yet
mkdir LexingtonPreschoolAcademy
cd LexingtonPreschoolAcademy

# Run these commands no matter what
dotnet new sln --name LexingtonPreschoolAcademy

dotnet new webapi -o LexingtonPreschoolAcademy-API

dotnet sln add LexingtonPreschoolAcademy-API

dotnet dev-certs https --trust
```

# Set up ssl and https

- We are doing this because dotnet doesn't seem to work too well with https certs on ubuntu 23 (non-lts version). Maybe there's something that I am not doing correctly for it to work, however, I know of an alternative way of acheiving the same effect. using an ssl-proxy (for ssl port handling) and mkcert (for certificate generation)
- First you will need node 16+ installed

```bash

sudo apt-get install wget libnss3-tools
wget https://github.com/FiloSottile/mkcert/releases/download/v1.4.3/mkcert-v1.4.3-linux-amd64
sudo mv mkcert-v1.4.3-linux-amd64 /usr/bin/mkcert
sudo chmod +x /usr/bin/mkcert

npm install -g local-ssl-proxy
```

# Generate https certs for web api

- go into the web api directory

-run the following command

```bash
mkcert -install
mkcert localhost

```

- go into the launchsettings.json and remove the https part of the json file. There should only be the http and iisexpress fields in the json file now.

# RUN THE API ALREADY!

- Now to simply run the web api run the following command

```
dotnet run | local-ssl-proxy --source 7212 --target 5263  --cert localhost.pem --key localhost-key.pem
```

Now simply go to [LocalhostSwaggerPage](https://localhost:7212/swagger)

# Set up GIT

- Now back to the root directory
- run git init
- make a git ignore file
- put the following content into the file

```.gitignore

*.pem


*.swp
*.*~
project.lock.json
.DS_Store
*.pyc
nupkg/

# Visual Studio Code
.vscode/

# Rider
.idea/

# Visual Studio
.vs/

# Fleet
.fleet/

# Code Rush
.cr/

# User-specific files
*.suo
*.user
*.userosscache
*.sln.docstates

# Build results
[Dd]ebug/
[Dd]ebugPublic/
[Rr]elease/
[Rr]eleases/
x64/
x86/
build/
bld/
[Bb]in/
[Oo]bj/
[Oo]ut/
msbuild.log
msbuild.err
msbuild.wrn
```

# Now the Frontend

- in the root directory simply run the following command to create a vue frontend

```bash
npm create vite@latest
```

- Your terminal should look very similar to this

![Screenshot from 2023-06-07 14-14-40](https://user-images.githubusercontent.com/47674962/244160068-a7d58173-2d8d-4084-b2c8-cd5a336e217c.png)
