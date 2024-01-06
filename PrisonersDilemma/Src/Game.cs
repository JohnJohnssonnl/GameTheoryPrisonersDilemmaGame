using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.Src
{
    internal class Game
    {
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public IBot Player1 { get; set; }
        public IBot Player2 { get; set; }
        private IList<Move> Moves { get; set; }
        private int NumOfRounds { get; set; }
        private int CurrentRound { get; set; }

        private readonly string docPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private StreamWriter outputFile;

        public Game(IBot player1, IBot player2, int numOfRounds)
        {
            Player1 = player1;
            Player2 = player2;
            NumOfRounds = numOfRounds;
            Moves = new List<Move>();
        }

        public void PlayGame()
        {
            using (outputFile = new StreamWriter(Path.Combine(docPath, $"PrisonersDilemmaTournament\\{Player1.Name()},{Player2.Name()}.csv"), false))
            {
                outputFile.WriteLine("Bot name;Move;Points;Round");

                for (CurrentRound = 1; CurrentRound <= NumOfRounds; CurrentRound++)
                {
                    playRound();
                }
            }
        }

        private void playRound()
        {
            //We play in this way so player 2 has no idea of player 1's move so it has no strategical advantage
            Move player1Move = Player1.MakeMove(Moves, CurrentRound);
            Move player2Move = Player2.MakeMove(Moves, CurrentRound);
            player1Move.Round = CurrentRound;
            player2Move.Round = CurrentRound;
            player1Move.Points = evaluate(player1Move.Response, player2Move.Response);
            player2Move.Points = evaluate(player2Move.Response, player1Move.Response);
            Player1Score += player1Move.Points;
            Player2Score += player2Move.Points;
            Moves.Add(player1Move);
            Moves.Add(player2Move);

            outputFile.WriteLine($"{Player1.Name()};{player1Move.Response};{player1Move.Points};{CurrentRound}");
            outputFile.WriteLine($"{Player2.Name()};{player2Move.Response};{player2Move.Points};{CurrentRound}");
        }

        private int evaluate(Response _response, Response _enemyResponse)
        {
            return _response switch
            {
                Response.Coorporate => _enemyResponse == Response.Coorporate ? 3 : 0,
                Response.Defect => _enemyResponse == Response.Defect ? 1 : 5,
                _ => 0,
            };
        }
    }
}
