using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class Bot2 : IBot
    {
        public string Name()
        {
            return "Dumber";
        }
        public Move MakeMove(IList<Move> moves)
        {
            return new Move
            {
                BotName = Name(),
                Response = Response.Defect
            };
        }
    }
}
