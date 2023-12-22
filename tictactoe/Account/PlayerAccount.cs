using tictactoe.DB.Services;
using tictactoe.DB.Services.Interfaces;
using tictactoe.Games;
using tictactoe.UI;
using TicTacToe;

namespace tictactoe.Account;

public class PlayerAccount
{
    public string UserName = "";
    public int Rating = 0;
    public int NumberOfGames = 0;

    public PlayerAccount(string UserName = " ", int Rating = 0, int NumberOfGames = 0)
    {
        this.UserName = UserName;
        this.Rating = Rating;
        this.NumberOfGames = NumberOfGames;
    }

    public void WinGame(string OpponentName, Game game, int id, Session session)
    {
        var currentGame = new GameHistory(game.GameRating, OpponentName, "Win", id);
        Rating += game.GameRating;
        session.HistoryService.AddHistory(this.UserName, currentGame);
        NumberOfGames++;
        session.AccountService.UpdateAccount(UserName, this);
    }

    public void LoseGame(string OpponentName, Game game, int id, Session session)
    {
        var currentGame = new GameHistory(-game.GameRating, OpponentName, "Loss", id);
        Rating -= game.GameRating;
        session.HistoryService.AddHistory(this.UserName, currentGame);
        NumberOfGames++;
        session.AccountService.UpdateAccount(UserName, this);
    }

    public void GetGameHistory(Session session)
    {
        Console.WriteLine("\n\t-- Account game history:\n\n");
        List<GameHistory> history = session.HistoryService.GetHistory(this.UserName);
        foreach (var elem in history)
        {
            Console.WriteLine($"\nOpponent Name: {elem.OpponentName}");
            Console.WriteLine($"Game Result: {elem.GameResult}");
            Console.WriteLine($"Game rating: {elem.GameRating}");
            Console.WriteLine($"Game ID: {elem.GameID}\n");
        }
    }

    public void GetStats(PlayerAccount account)
    {
        Console.WriteLine("\t-- Account stats:\n\n");
        Console.WriteLine($"\t-- UserName: {account.UserName}");
        Console.WriteLine($"\t-- Rating: {account.Rating}");
        Console.WriteLine($"\t-- Games played: {account.NumberOfGames}");
    }

    internal void WinGame(string userName, Game game, int v, object historyService, object accountService)
    {
        throw new NotImplementedException();
    }
}