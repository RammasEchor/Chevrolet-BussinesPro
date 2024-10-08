# Chevrolet - BusinessPro Interconnection System

This system has three parts:

## 1. Dispatch
Reads the created/moved files to a specified directory, parses the information in them, and sends it to BusinessPro API.

The dispatch is configured by environment variables:
 - API_INTERFACE_DIR: It is the path to the directory to monitor for new files.
 - BUSINESS_PRO_BASE_URL: The base url to which we will send information. Each model has the rest of the url to append to the base.

### Models

Since the API already has the Models, or tables, in which it wants to receive information, our job is to transform the information inside the files to an API model.

To avoid recoding all the models, we generate the API methods using NSwag. Each of our models has a generated class as a field that can communicate with the API. We just need to fill the fields of that generated class, and call the operation on that generated class.

## 2. API
Receives information from BusinessPro, and inserts it into a local database.

The API is configured by a appsettings.json file, which needs to be present when deploying the API.

The API is using diferent Models than the dispatch, and it is also using the EF Core Migrations feature. This helps to "rebuild" the database after there has been some changes on the models, without wiping all the data that it is already in there.

There are three steps in working with migrations:

### Creating/Changing the Models

When a model changes, or is created for the first time, you generate a migration:

````
dotnet ef migrations add MigrationName
````

This line generates the directory *Migrations* and some files inside it.


### Creating/Updating the Development Database

After generating the migration (changes in the models), you can *apply* the migration to an existing database, or create a new one, with the line:

````
dotnet ef database update
````

This line creates a new database with the necessary tables to mirror the models that you created, or, if you already have a database, it applies the changes *without* wiping the data that may already be there.

### Creating/Updating the Production Database

You may not have dotnet in the target system that can run the above command, so you need to use SQL to modify the production database:

````
dotnet ef migrations script
````

This line generates a SQL script from a blank database to the latest migration. If your production database has already some migrations applied to it, you may use:

````
dotnet ef migrations script FromThisMigration
````

This generates an SQL script that applies the changes *from* the named migration to the latest migration.

### Notes

- You generate migrations in the dev environment.
- Testing is done using swagger.

## 3. Deployment Scripts

We are deploying the system inside a windows 10 machine, using nssim as a helper. Nssim is the "Non sucking service manager", and installs/controls/stops/etc. the dispatch and the api as services.

To create a deployment, you need to run the task "deploy-win32". This task:
1. Calls the task "publish-win32", which runs the dotnet publish command with args that makes each project inside the solution to be compiled to win-32 (win-x86), to be self-contained (no runtime to be installed on the target machine), and to be compiled as a single file.
2.  Calls the script "create_deployment_win.sh", which copies the compiled programs (dispatch, and the api), with all the necessary files to config the system:
    - .bat for configuring the system using nssim
    - appsettings.json for the api
    - database.sql migration script for the api


