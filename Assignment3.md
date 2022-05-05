# EWU-CSCD378-2022-Spring

## Assignment 3

The purpose of this assignment is to solidify your learning of:
- Creating an API and deploying it to Azure
- Calling the API from the client using Axios
- Using Entity Framework to store data in SQL Server
- Configuring SQL Server for localhost development and Azure
- Entity Framework Migrations
- Local storage

## Feature
Add leaderboard to the application
- Allow the user to play a game
- At the end of the game get a name via a dialog
- Save the name in local storage so we don't have to ask again
- Call and API to save the data
- Create a Leaderboard page which displays the top 10 scores
- Determine a good algorithm for sorting scores

## Turn in Process
- On your fork, create an Assignment 3 branch 
- Update this branch (Fetch upstream) from the Assignment 3 branch in the class repo. [Assignment 3 in class repo](https://github.com/IntelliTect-Samples/EWU-CSCD379-2022-Spring/tree/Assignment3)
- Do your homework in your Assignment 3 branch
- Submit your pull request against Assignment 3 in the class repo
- Ask in Teams chat if you have questions or issues

## Instructions

**1. Create a leaderboard API Controller** ❌✅
- Create an endpoint that returns the top 10 scores (HttpGet) ❌✅
  - Results should include Name, average guesses, and number of games played ❌✅
- Create an endpoint that allows for posting a score (HttpPost) with data in the body ❌✅
  - A new name should add a new record ❌✅
  - An existing name should update that record ❌✅
- Save and load all data with Entity Framework to an Azure SQL database or LocalDb for debugging ❌✅
  - Table should be named "Player" and Players for the DbSet ❌✅
  - Fields should be: 
    - int PlayerId ❌✅
    - string Name ❌✅
    - int GameCount ❌✅
    - double AverageAttempts ❌✅
    - int AverageSecondsPerGame ❌✅
- The logic should reside in a service that is injected via dependency injection into the controller ❌✅
- Set up CORS (Cross Origin Resource Sharing) ❌✅

**2. Create a dialog for getting the user's name** ❌✅
- If we don't have the user's name, present the user with a dialog that allows them to type in their name ❌✅
- The users current name should show on the game page (upper right) ❌✅
  - This should be visible when setting/changing the name. It should change as the user types ❌✅
- The user should be able to click on their name to change it (with the same dialog) ❌✅
- Save the name in local storage and load it for the next game if it is set ❌✅
- If the name is not set, display Guest as the name. ❌✅
  - Clicking on this allows for preemptive setting of the name before the end of the game ❌✅
- Dialog must be persistent, doesn't close by clicking off the dialog ❌✅

**3. Save the Score and Seconds to complete** ❌✅
- Save the score and time to complete in seconds at the end of the game if we have a name. ❌✅
- If the user hasn't set a name, save the score and seconds as "Guest". (Be sure to prompt first) ❌✅
- Save should be done with an Axios Post ❌✅

**4. Create a Leaderboard Page** ❌✅
- Create a /leaderboard page in the application that shows the top scores ❌✅
- Use Axios to call the leaderboard API ❌✅
- Make a nice display of the returned data ❌✅
- Add a link on the front page to access the leaderboard ❌✅
- Add a link to the app bar to access the leaderboard ❌✅

**5. Unit testing** ❌✅
- Tests for the service ❌✅
- Integration tests for the controller ❌✅

**6. Deploy site to Azure** ❌✅
- Deploy API site with Github Action to Azure Web App ❌✅
- Unit Tests should run on build ❌✅
- Add API Base URL replacement to front end project ❌✅


## Extra Credit

- Unit testing on the client side (3) ❌✅
- Animate the leaderboard (3) ❌✅
- Create a logo (3) ❌✅
