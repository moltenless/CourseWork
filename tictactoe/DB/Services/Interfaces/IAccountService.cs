using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tictactoe.Account;

namespace tictactoe.DB.Services.Interfaces
{
    public interface IAccountService
    {
        PlayerAccount GetAccount(string userName);
        PlayerAccount GetAccount(int id);
        int GetAccountsCount();
        PlayerAccount[] GetAllAccounts();
        void AddAccount(PlayerAccount newAccount);
    }
}
