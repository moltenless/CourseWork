namespace tictactoe.UI;


public class CheckExceptions
{
    public void checkCommand(string command = " ")
    {
        if (command != "/computer" && command != "/friend" && command != "/exit" && command != "/stats" && command != "/menu")
        { throw new ArgumentOutOfRangeException(nameof(command), "Command doesn't exist!"); }
    }

    public void checkPlayerExistence(int index, int length)
    {
        if (index < 1 && index > length) { throw new IndexOutOfRangeException($"Index must be in range [1; {length}]"); }
    }


}