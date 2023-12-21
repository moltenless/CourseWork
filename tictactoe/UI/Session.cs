using tictactoe.Account;
using tictactoe.DB;
using tictactoe.DB.Services;
using tictactoe.Games;
using TicTacToe;

namespace tictactoe.UI;


public class Session
{
    public Interface screen { get; set; } = new Interface();
    public DataService Data { get; set; }
    public GameLauncher launcher { get; set; } = new GameLauncher();

    public void StartSession()
    {
        this.Data = new DataService(DBContext.GetDummyContext());
        screen.LoginScreen(this);
        screen.MenuScreen(this);
    }

    public void addPlayer(string username, int rating, int games_num)
    {
        PlayerAccount Player = new PlayerAccount(username, rating, games_num);
        Data.AddAccount(Player);
    }
    public void menuCommand(string command = "")
    {
        if (command == "/computer" || command == "/friend") { launcher.Launch(this, command); }
        if (command == "/stats") { screen.choosePlayerStats(this); screen.backToMenu(this); }
        else { endSession(); }
    }

    public void additionalCommand(string command = "")
    {
        if (command == "/menu") { screen.MenuScreen(this); }
        else if (command == "/stats") { screen.choosePlayerStats(this); screen.backToMenu(this); }
        else { endSession(); }
    }

    public void handleGame(Game game, DataService data)
    {
        Console.Write("\n\n\t-- Game is over!\n\t-- Game result: ");
        if (game.gameStatus == true) { Console.WriteLine($"{game.Winner.UserName} won 😀"); }
        else { Console.WriteLine("Draw 🙄"); }

        
        game.Winner.WinGame(game.Loser.UserName, game, (GameHistory.GameIDCounter + 1) / 2, data);
        GameHistory.GameIDCounter++;
        game.Loser.LoseGame(game.Winner.UserName, game, (GameHistory.GameIDCounter + 1) / 2, data);
        GameHistory.GameIDCounter++;

        screen.backToMenu(this);
    }

    public void endSession()
    {
        Console.WriteLine("\n\n\t-- You successfully finished the program!");
    }
}