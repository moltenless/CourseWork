namespace tictactoe.UI;


public class CheckExceptions
{
    public void checkCommand(string command = " ")
    {
        if (command != "/computer" && command != "/friend" && command != "/exit" && command != "/stats" && command != "/menu")
        { throw new ArgumentOutOfRangeException(nameof(command), "Command doesn't exist!"); }
    }
}