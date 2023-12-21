namespace tictactoe.Games;
using System;
using tictactoe.Account;
using tictactoe.UI;

public class Game
{
    public int GameRating = 0;

    public PlayerAccount Winner = new PlayerAccount();

    public PlayerAccount Loser = new PlayerAccount();

    public bool gameStatus;
    public int[,] Board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

    public Interface screen = new Interface();

    public Game(int gameRating)
    {
        GameRating = gameRating;
    }

    protected virtual int choosePosition(int turn)
    {
        int res;

        Random rand = new Random();
        res = rand.Next(1, 10);

        return res - 1;
    }

    public void applyMove(int turn, int index)
    {
        int position, row, col;
        while (true)
        {
            position = choosePosition(turn);
            row = position / 3;
            col = position - 3 * row;

            if (Board[row, col] == 0) break;
            Console.WriteLine("\n\t-- This position has been already chosen! Try another one)");
        }

        //Console.WriteLine($"\tPosition: [{row}][{col}]"); 
        Board[row, col] = index;
    }

    protected bool checkWinCondition()
    {
        int maind_sum = Math.Abs(Board[0, 0] + Board[1, 1] + Board[2, 2]);
        int subd_sum = Math.Abs(Board[0, 2] + Board[1, 1] + Board[2, 0]);
        if (maind_sum == 3 || subd_sum == 3) return true;

        int row_sum, col_sum;
        for (int i = 0; i < 3; i++)
        {
            row_sum = Math.Abs(Board[i, 0] + Board[i, 1] + Board[i, 2]);
            col_sum = Math.Abs(Board[0, i] + Board[1, i] + Board[2, i]);

            if (row_sum == 3 || col_sum == 3) return true;
        }

        return false;
    }

    public virtual void PlayGame(Session session, PlayerAccount Opponet)
    {
        List<PlayerAccount> gamePlayerList = new List<PlayerAccount>();
        gamePlayerList.Add(session.PlayerList[0]);
        gamePlayerList.Add(Opponet);

        Random rand = new Random();
        int turnIndex = rand.Next(0, 2);

        int turnCounter = 0, valueIndex = 1;
        bool win = false;

        Console.Clear();
        screen.BoardScreen(this, gamePlayerList[turnIndex].UserName);

        while (turnCounter < 9 && !win)
        {
            applyMove(turnIndex, valueIndex);
            Console.Write("\t-- Processing...");
            win = checkWinCondition();

            turnCounter++;
            turnIndex = 1 - turnIndex;
            valueIndex -= 2 * valueIndex;

            Thread.Sleep(750);
            Console.Clear();
            screen.BoardScreen(this, gamePlayerList[turnIndex].UserName);
        }

        gameStatus = win;
        Winner = gamePlayerList[1 - turnIndex];
        Loser = gamePlayerList[turnIndex];

        session.handleGame(this);
    }
}