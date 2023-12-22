using System.Collections.Generic;
using tictactoe.Account;
using tictactoe.DB.Services;
using tictactoe.Games;
namespace tictactoe.UI;

public class Interface
{

    private CheckExceptions checker = new CheckExceptions();
    public void LoginScreen(Session session)
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\t\t             -----LOGIN-----\n\n\n");

        Console.Write("\t\tEnter your username: ");
        string username = Console.ReadLine();

        Console.Write("\t\tEnter your current rating: ");
        int rating = Convert.ToInt32(Console.ReadLine());

        Console.Write("\t\tEnter number of games you played: ");
        int games_num = Convert.ToInt32(Console.ReadLine());

        session.addPlayer(username, rating, games_num);
    }

    public void MenuScreen(Session session)
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\t\t     WELCOME TO 'TIC TAC TOE'!!!");
        Console.WriteLine("\n\n\n\t\t\t\t\t\t\t\t\tMENU:\n\n");
        Console.WriteLine("\t-- Check 'Tic Tac Toe' stats [Command = /stats]");
        Console.WriteLine("\t-- Play 'Tic Tac Toe' with computer  [Command = /computer]");
        Console.WriteLine("\t-- Play 'Tic Tac Toe' with your friend [Command = /friend]");
        Console.WriteLine("\t-- Exit of 'Tic Tac Toe' app [Command =  /exit]");

        Console.Write("\t>> ");
        string? command = Console.ReadLine();
        checker.checkCommand(command);

        session.menuCommand(command);
    }

    public void BoardScreen(Game game, string CurrentPlayersTurn = "Computer")
    {
        Console.WriteLine($"\t~~ Current turn: {CurrentPlayersTurn}\n\n");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\t\t\t\t\t\t\t\t##     ##     ##     ##");
            Console.Write("\t\t\t\t\t\t\t\t##  ");
            for (int j = 0; j < 3; j++)
            {
                switch (game.Board[i, j])
                {
                    case -1:
                        Console.Write($"O  ##  ");
                        break;
                    case 0:
                        Console.Write($"-  ##  ");
                        break;
                    case 1:
                        Console.Write($"X  ##  ");
                        break;
                }
            }
            Console.WriteLine("\n\t\t\t\t\t\t\t\t##     ##     ##     ##");
            if (i < 2) Console.WriteLine("\t\t\t\t\t\t\t\t#######################");
        }
    }

    public void backToMenu(Session session)
    {
        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t    Choose an option");
        Console.WriteLine("\n\n\t-- Return to menu [Command = /menu]");
        Console.WriteLine("\t-- Check stats [Command = /stats]");
        Console.WriteLine("\t-- Exit of 'Tic Tac Toe' app [Command =  /exit]");

        Console.Write("\t>> ");
        string? command = Console.ReadLine();
        checker.checkCommand(command);

        session.additionalCommand(command);
    }

    public void chooseOpponentInterface(Session session)
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\t\t\t Choose your opponent!\n\n");

        Console.WriteLine($"\n\t-- Create new opponent account [Enter 0]");

        for (int i = 1; i < session.AccountService.GetAccountsCount(); i++)
        {
            if (session.AccountService.GetAccount(i).UserName != "Computer")
            { Console.WriteLine($"\t-- {session.AccountService.GetAccount(i).UserName} [Enter {i}]"); }
        }
    }

    public void choosePlayerStats(Session session)
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\t\t\t Choose player to show stats!\n\n");

        for (int i = 0; i < session.AccountService.GetAccountsCount(); i++)
        {
            if (session.AccountService.GetAccount(i).UserName != "Computer")
            { Console.WriteLine($"\t-- {session.AccountService.GetAccount(i).UserName} [Enter {i}]"); }
        }

        Console.Write("\t>> ");
        string playerIndex = Console.ReadLine();

        int index;
        bool ch = int.TryParse(playerIndex, out index);

        showPlayerStats(session, index);
    }

    public void showPlayerStats(Session session, int ind)
    {
        Console.Clear();
        PlayerAccount current = session.AccountService.GetAccount(ind);
        current.GetStats(current); 
        if (session.HistoryService.GetRecordsCount(ind) != 0) { session.AccountService.GetAccount(ind).GetGameHistory(session); }
    }
}