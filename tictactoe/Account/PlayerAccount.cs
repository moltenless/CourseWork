using tictactoe.DB.Services;
using tictactoe.Games;
using tictactoe.UI;
using TicTacToe;

namespace tictactoe.Account;

public class PlayerAccount
{
    public string UserName = "";
    public int Rating = 0;
    public int NumberOfGames = 0;
    //public List<GameHistory> History;    більше не потрібно, воно зберігається в базі даних

    public PlayerAccount(string UserName = " ", int Rating = 0, int NumberOfGames = 0)
    {
        this.UserName = UserName;
        this.Rating = Rating;
        this.NumberOfGames = NumberOfGames;
    }

    public void WinGame(string OpponentName, Game game, int id, DataService data)
    {
        var currentGame = new GameHistory(game.GameRating, OpponentName, "Win", id);
        Rating += game.GameRating;
        data.AddHistory(this.UserName, currentGame);
        NumberOfGames++;
    }

    public void LoseGame(string OpponentName, Game game, int id, DataService data)
    {
        var currentGame = new GameHistory(-game.GameRating, OpponentName, "Loss", id);
        Rating -= game.GameRating;
        data.AddHistory(this.UserName, currentGame);
        NumberOfGames++;
    }

    public void GetGameHistory(DataService data)
    {
        Console.WriteLine("\n\t-- Account game history:\n\n");
        List<GameHistory> history = data.GetHistory(this.UserName);
        foreach (var elem in history)
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