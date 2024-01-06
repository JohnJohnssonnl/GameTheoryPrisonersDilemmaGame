using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class AlwaysDefecting : IBot
    {
        public string Name()
        {
            return "Always Defecting";
        }
        public Move MakeMove(IList<Move> moves, int round)
        {
            return new Move
            {
                BotName = Name(),
                Response = Response.Defect
            };
        }
    }
}
