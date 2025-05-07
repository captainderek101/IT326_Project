# Ups & Downs: A social media website by Project Pick Me Up

Table of Contents:
- [Setup](#setup)
  - [Database](#database)
  - [API Keys](#api-keys)
  - [Running the website](#running-the-website)
- [HTTP Calls](#http-calls)
  - [Login page](#login-page)
  - [Home page](#home-page)
  - [View Post page](#view-post-page)
  - [Create Post page](#create-post-page)
  - [Browse Posts page](#browse-posts-page)

## Setup
### Database
The following Google Document contains instructions on downloading and installing SQL Server: https://docs.google.com/document/d/1lUWt5uUI-_A0jPzzCn88F4GF8itGxN8EC1rs7kfWo0Y/edit?usp=sharing

Once this setup is done, run the queries contained within the /sql folder in this repository. IMPORTANT NOTE: The "CreateUsersTable.sql" file should be run first, followed by "CreatePostsTable.sql", followed by the remaining queries in any order. This is because of Foreign Key constraints.

### API Keys
There are 2 external APIs used within this project which require API keys to use: the World News API and the Sentiment Analysis API. 

For both of these API keys, navigate to the AppHost appsettings.json. Below are directions for navigation.
1. Open Visual Studio
2. Go to Solution Explorer
3. Expand "Ups_Downs_API.AppHost"
4. Select "appsettings.json"

Within the "GoogleCloud" portion, there is a ApiKey and a empty string after, input the API key here. Follow the same logic for the world API section. 
  "GoogleCloud": {
    "ApiKey": "key goes here"
  },
  
  "WorldNewsApi": {
    "ApiKey": "key goes here"
  }

If you are Dr. Rishi Saripalle, we have provided you with the API keys in our Canvas submission comments.

### Running the website
Verify that the Database has been set up with all of the required tables and the project has been set up with the correct connection string for the Database. Verify that the API keys have been inserted into the project. If you have done these steps, you are ready to run the project!

In Visual Studio, set the "Startup Item" to "Ups_Downs_Api.AppHost" and click run. On certain computers you may get an error related to starting an endpoint on an occupied port: if this occurs, locate the launchsettings.json file in the Properties folder of the Ups_Downs_Api.AppHost project and modify the second port number under https -> applicationUrl (line 8) from 15292 to something like 15293. This should allow you to run the project successfully.

## HTTP Calls
Due to time constraints and the grading basis for this project, the web browser client of this website is in some parts buggy and incomplete. Therefore we have provided all of the API calls that make up the functionality of our website in the sections below. It is recommended to explore the webpages before using the API calls since that was the intended medium by which our product would have been used.

### Login page
To reach the login page endpoint, it uses a HTTP POST Request that uses a from body to recieve the json. The endpoint to the login page is https://localhost:7466/login. The Json structure is as follows `{ "Username":"testUsername", "Password":"testPassword" }`. For a seccessful login, the account you are loging into must exist.
### Home page

### View Post page

### Create Post page

### Browse Posts page
