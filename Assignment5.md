# EWU-CSCD378-2022-Spring

## Assignment 5

The purpose of this assignment is to solidify your learning of:

- Creating CRUD interface in a SPA with auth
- ASP.NET Core Indentity
- Use of JWTs as a bearer token
- Using policy-based authorization

## Features

### Create an editor for the available words ✅ (backend is all done)
  - Create a page named "WordEditor" that allows words to be edited ✅ (T)
    - Support deleting a word ✅ (T)
    - Support adding a new word ✅ (T)
    - Editing words is not supported ✅ (T)
    - Duplicate words should not be allowed ✅ (T)
    - Support changing the common word boolean flag ✅ (T)
    - Words should be sorted alphabetically ✅ (T)
  - Provide a text box for searching words AS YOU TYPE which supports searching for words starting with letters specified ❌✅ (L, **DO THIS IN THE COMPONENT**)
  - Provide a menu item for navigating to the WordEditor page ✅ (S)
    - Anyone can look at the word list ✅ (S)
    - Word list is paginated (10-100 per page) ✅ (S)
  - Any logged in user can change the common word flag ❌✅ (S)
    - There is a login page for users to sign up/log in ❌✅ (L, may be need more work)
  - Only users over 21 years of age (based on birthday) with a claim of MasterOfTheUniverse can add and remove words ❌✅ (T)
  - Users can be set up at start up (apriori), there does not need to be a sign up mechanism ❌✅ (S???)

## Turn in Process

- On your fork, create an Assignment5 branch
- Update this branch (Fetch upstream) from the Assignment5 branch in the class repo. [Assignment5 in class repo](https://github.com/IntelliTect-Samples/EWU-CSCD379-2022-Spring/tree/Assignment5)
- Do your homework in your Assignment5 branch
- Submit your pull request against Assignment5 in the class repo
- Ask in Teams chat if you have questions or issues

## Extra Credit

- Find a bug in the application, create an issue, submit a pull request against the issue
- Add the ability to sign up for an account by inputting an email and password
- Allow the user to elevate their level of privelage by inputting a secret phrase
- Select pagination record count
