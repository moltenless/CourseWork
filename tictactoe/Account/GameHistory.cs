namespace TicTacToe;

public class GameHistory
{
    public static int GameIDCounter = 1;

    public readonly int GameRating;
    public readonly string OpponentName = "";
    public readonly string GameResult = "";
    public readonly int GameID;

    public GameHistory(int GameRating, string OpponentName, string GameResult, int GameID)
    {
        this.GameRating = GameRating;
        this.OpponentName = OpponentName;
        this.GameResult = GameResult;
        this.GameID = GameID;
    }
}