Simple C# implementation of the Game Theory Prisoners Dilemma game.
Made for .NET 7, just make sure to have Visual Studio, no extra reference packages required.
A bot can in a match choose to cooporate or defect and for each choise can get a reward depending on the other players action as perfectly explained in "What The Prisoner's Dilemma Reveals About Life, The Universe, and Everything" from Veritasium on Youtube.

You can create your own strategy by simply creating a bot in the BOT folder which implements IBot. You get a list with moves made previously in the game so you can adjust your strategy for your next move accordingly.

TODO list (this is just a small section of what could be improved): 
- Add more strategies (BOTS)
- Refactor code, especially the game.cs is very messy, but it works for now
- Make game rule variations and extendable so everyone can create their own easy rules for the game and see how that affects outcome
- Implement "inperfections" affecting results
- Implement more datacontracts with the data for full serialization in XML to get a game state and debug through from there
