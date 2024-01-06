using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class TFT : IBot
    {
        public string Name()
        {
            return "TFT";
        }
        public Move MakeMove(IList<Move> moves, int round)
        {
            //Gets the previous move of the opponent, and strike back if the opponent was naughty last round, otherwise be nice
            Move? prevEnemyMove = moves.FirstOrDefault(p => p.BotName != Name() && p.Round == round -1);

            return prevEnemyMove != null && prevEnemyMove.Response == Response.Defect
                ? new Move
                {
                    BotName = Name(),
                    Response = Response.Defect
                }
                : new Move
                {
                    BotName = Name(),
                    Response = Response.Coorporate
                };
        }
    }
}
