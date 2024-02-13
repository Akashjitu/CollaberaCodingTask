#  Santander - Developer Coding Test.
## _About project_
sing ASP.NET Core, implement a RESTful API to retrieve the details of the first n "best stories" from the Hacker News API, where n is specified by the caller to the API. The Hacker News API is documented here: https://github.com/HackerNews/API . 
The IDs for the "best stories" can be retrieved from this URI: https://hacker-news.firebaseio.com/v0/beststories.json . 
The details for an individual story ID can be retrieved from this URI: https://hacker-news.firebaseio.com/v0/item/21233041.json (in this case for the story with ID 21233041 ) 

## _How to Run:_
1. Easy way to run this app in Visual Studio 2022 (you can use free community edition. ).
2. Open CollaberaCodingTask.sln file in Visual Studio 2022 (as Admin account) and click on run Button.
3. It'll open Swagger, Where you can find all the end Points.

## Development
- Created this app using .Net 7.O.(.Net Core)
- I'm using Small MicroService with this app.
- Created Separate class for Response, so user can handle Exception.(https://github.com/Akashjitu/CollaberaCodingTask/blob/master/CollaberaCodingTask/Models/RpgModels/ServiceResponse.cs)
- Using Async Programming to reduce the load.



## Features
There are 3 end point. (https://github.com/Akashjitu/CollaberaCodingTask/blob/master/CollaberaCodingTask/Controllers/NewsController.cs)
1. GetFirstBestStory: Provide the first best story
2. GetBestStories: Get all Best Story ID.
3. GetStory: Get story based on ID.

## Note
- I haven't used any third party liberty.
- This App is Working on Https protocol. maybe require some permission.

