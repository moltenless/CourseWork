using tictactoe.Account;
using tictactoe.Games;

namespace tictactoe.UI;


public class GameLauncher
{
    private CheckExceptions checker = new CheckExceptions();
    public int chooseFriendOpponent(Session session)
    {
        Console.Write("\t>> ");
        string ind = Console.ReadLine();

        int index;
        bool ch = int.TryParse(ind, out index);

        if (index == 0) { session.screen.LoginScreen(session); return session.AccountService.GetAccountsCount() - 1; }

        return index;
    }

    public void Launch(Session session, string GameType)
    {
        int oppIndex = 0;
        if (GameType == "/computer")
        {
            Console.WriteLine("\n\n\t-- Game with computer!");
            Thread.Sleep(1500);

            List<PlayerAccount> players = session.AccountService.GetAllAccounts();
            for (int i = 1; i < players.Count; i++)
            {
                if (players[i].UserName == "Computer") { oppIndex = i; break; }
            }

            if (oppIndex == 0)
            {
                PlayerAccount Computer = new PlayerAccount("Computer");
                session.AccountService.AddAccount(Computer);

                oppIndex = session.AccountService.GetAccountsCount() - 1;
            }

            Game game = new GameWithComputer(1);
            game.PlayGame(session, session.AccountService.GetAccount(oppIndex));
        }

        else if (GameType == "/friend")
        {
            Console.WriteLine("\n\t-- Game with friend!");
            Thread.Sleep(1500);

            if (session.AccountService.GetAccountsCount() < 2 || session.AccountService.GetAccountsCount() < 3 && session.AccountService.GetAccount(1).UserName == "Computer")
            {
                Console.WriteLine("\t-- To continue second player also need to login!");
                Thread.Sleep(2500);
                session.screen.LoginScreen(session);
                oppIndex = session.AccountService.GetAccountsCount() - 1;
            }

            else
            {
                session.screen.chooseOpponentInterface(session);
                oppIndex = chooseFriendOpponent(session);
            }

            Game game = new GameWithFriend(1);
            game.PlayGame(session, session.AccountService.GetAccount(oppIndex));
        }
    }
}