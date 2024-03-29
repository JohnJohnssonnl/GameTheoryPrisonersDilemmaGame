﻿using System.Reflection;

namespace PrisonersDilemma.Src
{
    internal class Tournament
    {
        private const string botsNameSpace = "PrisonersDilemma.BOT";
        private readonly IList<IBot> activeBots = new List<IBot>();
        public IList<Game> Games = new List<Game>();
        public IDictionary<string, int> ScoreList = new Dictionary<string, int>();
        private readonly string docPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public void PlayTournament()
        {
            InitializeTournament();

            string directory = Path.Combine(docPath, $"PrisonersDilemmaTournament");

            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            _ = Directory.CreateDirectory(directory);

            foreach (Game game in Games)
            {
                game.PlayGame();
                _ = ScoreList.TryGetValue(game.Player1.Name(), out int currentCountPlayer1);
                ScoreList[game.Player1.Name()] = currentCountPlayer1 + game.Player1Score;
                _ = ScoreList.TryGetValue(game.Player2.Name(), out int currentCountPlayer2);
                ScoreList[game.Player2.Name()] = currentCountPlayer2 + game.Player2Score;
            }

            using (StreamWriter outputFile = new(Path.Combine(docPath, "PrisonersDilemmaTournament\\TournamentResults.csv"), false))
            {
                outputFile.WriteLine("Bot name; Score");

                foreach (KeyValuePair<string, int> bot in ScoreList)
                {
                    outputFile.WriteLine($"{bot.Key};{bot.Value}");
                }
            }

            Console.WriteLine("Tournament finished, results in CSV format can be found on the desktop in the PrisonersDillemmaTournament folder");
        }

        private void InitializeTournament()
        {
            foreach (IBot bot in activeBots)
            {
                foreach (IBot botOpponent in activeBots)
                {
                    if (botOpponent.Name() != bot.Name())
                    {
                        //Each bot will be once a first and second player
                        Games.Add(new Game(bot, botOpponent, 200));
                    }
                }
            }
        }

        public Tournament()
        {
            var bots = from t in Assembly.GetExecutingAssembly().GetTypes()
                   where t.IsClass && t.Namespace == botsNameSpace
                   select t;

            using IEnumerator<Type> BotContender = bots.GetEnumerator();

            Console.WriteLine("Building bot list to add to the tournament");
            while (BotContender.MoveNext())
            {
                if (Activator.CreateInstance(BotContender.Current) is IBot currentBot)
                {
                    activeBots.Add(currentBot);
                    Console.WriteLine($"Added bot to the tournament: {currentBot.Name()}");
                }
            }
        }
    }
}
