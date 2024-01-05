using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class Bot1 : IBot
    {
        public string Name()
        {
            return "Dumb";
        }
        public Move MakeMove(IList<Move> moves)
        {
            return new Move {   BotName = Name(),
                                Response = Response.Coorporate};
        }
    }
}
