using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tictactoe.Account;
using tictactoe.DB.Entities;
using tictactoe.DB.Repositories;
using tictactoe.DB.Services.Interfaces;

namespace tictactoe.DB.Services
{
    internal class AccountService : IAccountService
    {
        private AccountRepository accountsRepository;
        public DBContext Context { get; set; }

        public AccountService(DBContext context)
        {
            accountsRepository = new AccountRepository(context);

            this.Context = context;
        }

        public void AddAccount(PlayerAccount newAccount)
        {
            AccountEntity account = new AccountEntity
            {
                NumberOfGames = newAccount.NumberOfGames,
                Rating = newAccount.Rating,
                UserName = newAccount.UserName,
            };

            HistoryEntity historyEntity = new HistoryEntity
            {
                UserName = account.UserName,
                History = new List<RecordEntity>()
            };
            HistoryRepository historyRepository = new HistoryRepository(Context);
            historyRepository.Create(historyEntity);

            accountsRepository.Create(account);
        }

        public void UpdateAccount(string userName, PlayerAccount account)
        {
            AccountEntity entity = new AccountEntity
            {
                NumberOfGames = account.NumberOfGames,
                Rating = account.Rating,
                UserName = account.UserName,
            };

            accountsRepository.Update(userName, entity);
        }

        public PlayerAccount GetAccount(string userName)
        {
            AccountEntity account = accountsRepository.Read(userName);
            PlayerAccount player = new PlayerAccount
            {
                NumberOfGames = account.NumberOfGames,
                Rating = account.Rating,
                UserName = account.UserName,
            };
            return player;
        }

        public PlayerAccount GetAccount(int id)
        {
            AccountEntity account = accountsRepository.Read(id);
            PlayerAccount player = new PlayerAccount
            {
                NumberOfGames = account.NumberOfGames,
                Rating = account.Rating,
                UserName = account.UserName,
            };
            return player;
        }

        public int GetAccountsCount() => accountsRepository.ReadAll().Count;

        public List<PlayerAccount> GetAllAccounts()
        {
            List<AccountEntity> old = accountsRepository.ReadAll();
            List<PlayerAccount> accounts = new List<PlayerAccount>();
            int n = GetAccountsCount();
            for (int i = 0; i < n; i++)
            {
                accounts.Add(GetAccount(old[i].UserName));
            }
            return accounts;
        }
    }
}
