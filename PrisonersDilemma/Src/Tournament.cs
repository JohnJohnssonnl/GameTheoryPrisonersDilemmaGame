using System.Reflection;

namespace PrisonersDilemma.Src
{
    internal class Tournament
    {
        private     const string botsNameSpace = "PrisonersDilemma.BOT";
        private     readonly IList<IBot> activeBots = new List<IBot>();
        public      IList<Game> Games = new List<Game>();
        public      IDictionary<string, int> ScoreList = new Dictionary<string, int>();
        
        public void PlayTournament()
        {
            InitializeTournament();

            foreach(Game game in Games)
            {
                game.PlayGame();
                ScoreList.TryGetValue(game.Player1.Name(), out var currentCountPlayer1);
                ScoreList[game.Player1.Name()] = currentCountPlayer1 + game.Player1Score;
                ScoreList.TryGetValue(game.Player2.Name(), out var currentCountPlayer2);
                ScoreList[game.Player2.Name()] = currentCountPlayer2 + game.Player2Score;
            }

            foreach(var bot in ScoreList)
            {
                Console.WriteLine($"Total score for bot {bot.Key} is {bot.Value}");
            }
        }

        void InitializeTournament()
        {
            foreach (IBot bot in activeBots)
            {
                foreach (IBot botOpponent in activeBots)
                {
                    if(botOpponent.Name() != bot.Name())
                    {
                        //Each bot will be once a first and second player
                        Games.Add(new Game(bot, botOpponent, 20));
                    }
                }
            }
        }

        public Tournament()
        {
            IEnumerable<Type> bots;

            bots = from t in Assembly.GetExecutingAssembly().GetTypes()
                   where t.IsClass && t.Namespace == botsNameSpace
                   select t;

            using IEnumerator<Type> BotContender = bots.GetEnumerator();
            while (BotContender.MoveNext())
            {
                if (Activator.CreateInstance(BotContender.Current) is IBot currentBot)
                {
                    activeBots.Add(currentBot);
                    Console.WriteLine($"Added bot {currentBot.Name()}");
                }
            }
        }
    }
}
