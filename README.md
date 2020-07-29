# WorkCast
## Requirements
* SQL Server and SQL Server Management Studio.
* Visual Studio (2019 recommended)
* Visual Studio Code (optional)
* Node JS
* NPM
## Installation
#### 1. Set up the database
Open Microsoft SQL Server Management Studio and run the CREATE_DATABASE.sql script
#### 2. Set up the API
Open Visual Studio, choose 'Open a project or solution' and select the WorkCast.sln file, Once the project has opened, run the project
#### 3. Test the API with Postman
Open Postman, in the top left, click on Import, then upload files and select the POSTMAN_COLLECTION.json file, the collection will then appear under the collections tab on the left, choose a request and press Send.
#### 4. Set up the Angular client
Open up Visual Studio Code, then click file followed by open folder and select the WorkcastClient folder. Once opened, click on Terminal, followed by new Terminal. This will open up a terminal within VS Code. Enter the following command to install the required node modules. Alternitively, open the folder in a command prompt/terminal and run the following command:

`npm i`

Once the node modules have been installed, you can then run the Angular application using `ng serve`, then it can be accessed in the browser at https://localhost:4200
Alternatively, use `ng serve -o` to have the browser open automatically.
