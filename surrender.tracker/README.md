# Surrender Tracker
A small CLI app which uses the Riot Games League of Legends API to track how many games an account has won or lost from surrendering. 
## Features
- A breakdown of the surrender outcomes from the last 100 games played by the summoner
- A direct link to view the stats of any surrendered game
## Limitations
- The Riot API has heavy rate limiting so you may find the requests take a while to complete. We're restricted to 100 requests every 2 mins. This app defaults to using all 100 requests to give as large of a sample size as possible.
- Currently hard-coded to only work on EUW1 as that's where I play. *May update in the future to support other reqions more easily*
## How to run
1. Clone this repo `git clone https://github.com/EliotTaylor1/surrender.tracker.git`
2. From the project root run `dotnet run`
3. Enter your API key
4. Enter the summoner's name
5. Enter the summoner's tag (Without the #)
6. Choose the queue type
7. Wait for the requests to Riot API to complete
8. View results
### Where to get a Riot API Key?
1. Go to `https://developer.riotgames.com` and login
2. Click on your name in the top right
3. Select dashboard
4. Scroll down and select generate API key
5. Paste that key in when you run the app
