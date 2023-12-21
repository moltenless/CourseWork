using tictactoe.Games;
using TicTacToe;

namespace tictactoe.Account;

public class PlayerAccount
{
    public string UserName = "";
    public int Rating = 0;
    public int NumberOfGames = 0;
    public List<GameHistory> History = new List<GameHistory>();

    public PlayerAccount(string UserName = " ", int Rating = 0, int NumberOfGames = 0)
    {
        this.UserName = UserName;
        this.Rating = Rating;
        this.NumberOfGames = NumberOfGames;
    }

    public void WinGame(string OpponentName, Game game)
    {
        var currentGame = new GameHistory(game.GameRating, OpponentName, "Win");
        Rating += game.GameRating;
        History.Add(currentGame);
        NumberOfGames++;
    }

    public void LoseGame(string OpponentName, Game game)
    {
        var currentGame = new GameHistory(-game.GameRating, OpponentName, "Loss");
        Rating -= game.GameRating;
        History.Add(currentGame);
        NumberOfGames++;
    }

    public void GetGameHistory()
    {
        Console.WriteLine("\n\t-- Account game history:\n\n");
        foreach (var elem in History)
        {
            Console.WriteLine($"\nOpponent Name: {elem.OpponentName}");
            Console.WriteLine($"Game Result: {elem.GameResult}");
            Console.WriteLine($"Game rating: {elem.GameRating}");
            Console.WriteLine($"Game ID: {elem.GameID}\n");
        }
    }

    public void GetStats()
    {
        Console.WriteLine("\t-- Account stats:\n\n");

        Console.WriteLine($"\t-- UserName: {UserName}");
        Console.WriteLine($"\t-- Rating: {Rating}");
        Console.WriteLine($"\t-- Games played: {NumberOfGames}");
    }
}