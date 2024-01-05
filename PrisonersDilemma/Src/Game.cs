using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.Src
{
    internal class Game
    {
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public IBot Player1 { get; set; }
        public IBot Player2 { get; set; }
        IList<Move> Moves { get; set; }
        int NumOfRounds { get; set; }

        public Game(IBot player1, IBot player2, int numOfRounds)
        {
            Player1 = player1;
            Player2 = player2;
            NumOfRounds = numOfRounds;
            Moves = new List<Move>();
        }

        public void PlayGame()
        {
            for(int i = 1; i <= NumOfRounds; i++)
            {
                playRound();
            }

            Console.WriteLine($"{Player1.Name()} scored in this game {Player1Score} points");
            Console.WriteLine($"{Player2.Name()} scored in this game {Player2Score} points");
        }

        void playRound()
        {
            //We play in this way so player 2 has no idea of player 1's move so it has no strategical advantage
            Move player1Move = Player1.MakeMove(Moves);
            Move player2Move = Player2.MakeMove(Moves);
            player1Move.Points = evaluate(player1Move.Response, player2Move.Response);
            player2Move.Points = evaluate(player2Move.Response, player1Move.Response);
            Player1Score += player1Move.Points;
            Player2Score += player2Move.Points;
            Moves.Add(player1Move);
            Moves.Add(player2Move);

            Console.WriteLine($"{Player1.Name()} move: {player1Move.Response}, scoring {player1Move.Points} points");
            Console.WriteLine($"{Player2.Name()} move: {player2Move.Response}, scoring {player2Move.Points} points");
        }

        int evaluate(Response _response, Response _enemyResponse)
        {
            switch(_response)
            {
                case Response.Coorporate:
                    return _enemyResponse == Response.Coorporate ? 3 : 0;
                case Response.Defect:
                    return _enemyResponse == Response.Defect ? 1 : 5;
            }
            return 0;
        }
    }
}
