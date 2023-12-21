namespace tictactoe.Games;


public class GameWithComputer : Game
{
    public GameWithComputer(int gameRating) : base(gameRating)
    {
    }

    protected override int choosePosition(int turn)
    {
        int res;

        if (turn % 2 != 0)
        {
            Random rand = new Random();
            res = rand.Next(1, 10);
            Thread.Sleep(1000);
        }

        else
        {
            Console.Write("\n\n\t-- Enter a position of your sign [from 1 to 9]: ");
            res = Convert.ToInt32(Console.ReadLine());
        }

        return res - 1;
    }
}