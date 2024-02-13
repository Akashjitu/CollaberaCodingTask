#  Santander - Developer Coding Test.

## _About project_
Using ASP.NET Core, implement a RESTful API to retrieve the details of the first n "best stories" from the Hacker News API, where n is specified by the caller to the API. The Hacker News API is documented here: https://github.com/HackerNews/API . 
The IDs for the "best stories" can be retrieved from this URI: https://hacker-news.firebaseio.com/v0/beststories.json . 
The details for an individual story ID can be retrieved from this URI: https://hacker-news.firebaseio.com/v0/item/21233041.json (in this case for the story with ID 21233041 ) 
## Prerequisites
1. Visual studio 2022 community edition or Visual Code.
2.  net7.0 SDK.
3. Admin Permission or Admin Account.

## _How to Run:_
1. **Visual Studio 2022 (you can use free community edition. )**
	- Open Visual Studio 2022 as Admin account
	- Go to File menu --> Open --> Project/Solution.
	- Select "CollaberaCodingTask.sln" Click on Open
	- Go to Build menu --> Select Build Soultion or Just Press "CTRL+Shify+B".
	- Ones build Success.
	- **Click F5 to Run the app.**
	- Swagger will Open automatically, if not getting open, Click on this URL https://localhost:7041/swagger/index.html
2. **Visual Studio Code (This is Free IDE)**
	- Open Visual Code as Admin account
	- Go to File menu --> Open Folder
	- Select "CollaberaCodingTask Folder --> CollaberaCodingTask Folder" Click on Open
	- Go to View menu --> Select Terminal or Just Press "CTRL+~" to open Terminal.
	- In Terminal run the command **"dotnet watch run".**
	- Swagger will Open automatically, if not getting open, Click on this URL http://localhost:5050/swagger/index.html
	- 
3. **PowerShell**
    - Open PowerShell Terminal.
    - Got "CollaberaCodingTask --> CollaberaCodingTask" Folder.
    - In Terminal run the command **"dotnet watch run".**

## Swagger Action Methon
There are 3 end point. (https://github.com/Akashjitu/CollaberaCodingTask/blob/master/CollaberaCodingTask/Controllers/NewsController.cs)
1. **GetFirstBestStory**: Provide the first best story
2. **GetBestStories**: Get all Best Story Ids.
3. **GetStory**: Get story based on Id.

## Note
- This App is Working on Https protocol. maybe require some permission.
- **Port can be change,because it's not static**.
- **Please first check Port already not in use**.
## Development
- Created this app using TargetFramework **net7.0** (.Net Core) 
- I'm using Small MicroService with this app.
- App also have **Retry Policy** using **Polly**. 
- Created Separate class for Response, so user can handle Exception.(https://github.com/Akashjitu/CollaberaCodingTask/blob/master/CollaberaCodingTask/Models/RpgModels/ServiceResponse.cs)
- Using Async Programming to reduce the load.

## Not Include 
**As of now, I haven't included any Unit Tests. If you require unit tests for the application, kindly inform me, and I'll be happy to incorporate them.**
**Unit Test was not mentioned in the requirement.**


