namespace tictactoe.Games;


public class GameWithFriend : Game
{
    public GameWithFriend(int gameRating) : base(gameRating)
    {
    }

    protected override int choosePosition(int turn)
    {
        int res;

        Console.Write("\n\n\t-- Enter a position of your sign [from 1 to 9]: ");
        res = Convert.ToInt32(Console.ReadLine());

        return res - 1;
    }
}