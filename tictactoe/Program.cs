using tictactoe.DB;
using tictactoe.DB.Services;
using tictactoe.DB.Services.Interfaces;
using tictactoe.UI;

namespace tictactoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DBContext dbContext = DBContext.GetDummyContext();
                DataService dataService = new DataService(dbContext);

                IAccountService accountService = (IAccountService)dataService;
                IHistoryService historyService = (IHistoryService)dataService;

                Session session = new Session(accountService, historyService);
                session.StartSession();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nException caught!!");
                Console.WriteLine(e.ToString());
                Console.ReadLine();
                return;
            }
        }
    }
}