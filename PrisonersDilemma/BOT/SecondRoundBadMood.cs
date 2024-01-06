using PrisonersDilemma.Src;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.BOT
{
    internal class SecondRoundBadMood : IBot
    {
        public string Name()
        {
            return "Second round bad mood";
        }
        public Move MakeMove(IList<Move> moves, int round)
        {
            return (round % 2 == 0)
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
