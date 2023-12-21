using tictactoe.UI;

namespace tictactoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Session session = new Session();
                session.StartSession();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nException caught!!");
                Console.WriteLine(e.ToString());
                return;
            }
        }
    }
}