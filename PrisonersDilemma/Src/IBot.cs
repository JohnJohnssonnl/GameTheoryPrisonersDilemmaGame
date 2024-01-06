namespace PrisonersDilemma.Src
{
    internal interface IBot
    {
        abstract string Name();
        abstract Move MakeMove(IList<Move> moves, int round);

    }
}
