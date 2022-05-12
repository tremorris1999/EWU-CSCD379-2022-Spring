# EWU-CSCD378-2022-Spring

## Assignment 4

The purpose of this assignment is to solidify your learning of:

- Responsive design for a variety of devices.
- Using a more complex API
- Creating services that use multiple EF classes (GET and POST)

## Features

- Make all pages responsive ❌✅
  - 1080p desktop ❌✅
  - iPad Air
  - Samsung Galaxy S20 Ultra Super Mega Excellent ❌✅
  - IPhone SE ❌✅
- Create a improved landing page and site theme (Background, make it look attractive to play) ❌✅
  - Theme should extend all pages (Maybe not the ad page 😁) ❌✅
- Add an instructions page that is available via the hamburger menu that details the features of the game and how to play ❌✅
- Create a new Wordle game page that reuses components but will provide the same word for a specific day. Everyone going to the page that day will get the same word. The page should indicate Wordle of the Day or something like that ❌✅
- Create a page that lists the last 10 daily words with statistics. Number of plays, Average score, Average time. (just list the date, don't show the word silly) ❌✅
  - It should indicate if the user has played that day ❌✅
  - Clicking on the item should take the player to that game (Extra Credit) ❌✅

## Turn in Process

- On your fork, create an Assignment4 branch
- Update this branch (Fetch upstream) from the Assignment4 branch in the class repo. [Assignment4 in class repo](https://github.com/IntelliTect-Samples/EWU-CSCD379-2022-Spring/tree/Assignment4)
- Do your homework in your Assignment4 branch
- Submit your pull request against Assignment4 in the class repo
- Ask in Teams chat if you have questions or issues

## Hints

For this assignment, fewer guidelines are going to be given. If we discuss ideas in class, feel free to PR them here and we will merge into the assignment.

- We want to push you to learn to make architectural decisions and follow the patterns we have applied in the past. However, if this is too hard, please let us know.
- It will be necessary to create a controller (and a service) for the daily words stats page
- Look a using a URL parameter to jump to the game at a specific date. [Stack Overflow](https://stackoverflow.com/questions/48068520/nuxt-js-how-to-get-route-url-params-in-a-page)

## Extra Credit

- Clicking on an item in the daily word stats page should take the player to that game and allow them to play it
- Create another ad page and choose one at random
