using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class AlwaysCoorporating : IBot
    {
        public string Name()
        {
            return "Always Coorporating";
        }
        public Move MakeMove(IList<Move> moves)
        {
            return new Move {   BotName = Name(),
                                Response = Response.Coorporate};
        }
    }
}
