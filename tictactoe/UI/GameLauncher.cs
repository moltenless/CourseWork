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

        if (index == 0) { session.screen.LoginScreen(session); return session.PlayerList.Count - 1; }

        checker.checkPlayerExistence(index, session.PlayerList.Count - 1);
        return index;
    }

    public void Launch(Session session, string GameType)
    {
        int oppIndex = 0;
        if (GameType == "/computer")
        {
            Console.WriteLine("\n\n\t-- Game with computer!");
            Thread.Sleep(1500);

            for (int i = 1; i < session.PlayerList.Count; i++)
            {
                if (session.PlayerList[i].UserName == "Computer") { oppIndex = i; break; }
            }

            if (oppIndex == 0)
            {
                PlayerAccount Computer = new PlayerAccount("Computer");
                session.PlayerList.Add(Computer);

                oppIndex = session.PlayerList.Count - 1;
            }

            Game game = new GameWithComputer(1);
            game.PlayGame(session, session.PlayerList[oppIndex]);
        }

        else if (GameType == "/friend")
        {
            Console.WriteLine("\n\t-- Game with friend!");
            Thread.Sleep(1500);

            if (session.PlayerList.Count < 2 || session.PlayerList.Count < 3 && session.PlayerList[1].UserName == "Computer")
            {
                Console.WriteLine("\t-- To continue second player also need to login!");
                Thread.Sleep(2500);
                session.screen.LoginScreen(session);
                oppIndex = session.PlayerList.Count - 1;
            }

            else
            {
                session.screen.chooseOpponentInterface(session);
                oppIndex = chooseFriendOpponent(session);
            }

            Game game = new GameWithFriend(1);
            game.PlayGame(session, session.Data.GetAccount(oppIndex));
        }
    }
}