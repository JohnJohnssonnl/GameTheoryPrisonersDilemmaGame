namespace PrisonersDilemma.Src
{
    interface IBot
    {
        abstract string Name();
        abstract Move MakeMove(IList<Move> moves, int round);

    }
}
