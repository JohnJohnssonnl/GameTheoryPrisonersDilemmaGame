using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class Probe : IBot
    {
        public string Name()
        {
            return "Probe";
        }
        public Move MakeMove(IList<Move> moves, int round)
        {
            Move? prevEnemyMove = moves.FirstOrDefault(p => p.BotName != Name() && p.Round == round - 1);
            Move? probedFriendlyMove = moves.FirstOrDefault(p => p.BotName == Name() && p.Round == round - 2);

            return round == 1 || (prevEnemyMove != null && prevEnemyMove.Response == Response.Coorporate && probedFriendlyMove != null && probedFriendlyMove.Response == Response.Defect)
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
