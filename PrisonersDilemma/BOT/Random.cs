using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class Random : IBot
    {
        public string Name()
        {
            return "Random";
        }
        public Move MakeMove(IList<Move> moves)
        {
            return new Move {   BotName = Name(),
                                Response = new System.Random().Next(0,2) == 0? Response.Coorporate : Response.Defect};
        }
    }
}
