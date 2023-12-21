using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tictactoe.Account;
using tictactoe.DB.Entities;
using tictactoe.DB.Repositories.Interfaces;

namespace tictactoe.DB.Repositories
{
    internal class AccountRepository : IRepository<AccountEntity, string>
    {
        private DBContext context;

        public AccountRepository(DBContext context)
        {
            this.context = context;
        }

        public void Create(AccountEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Account Entity was null");
            context.Accounts.Add(entity);
        }

        public void Delete(string userName)
        {
            AccountEntity account = Read(userName);
            context.Accounts.Remove(account);
        }

        public AccountEntity Read(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException("Name was null");

            var namedAccounts = context.Accounts.Where((e) => e.UserName == userName);

            ArgumentException absence = new ArgumentException("There are not accounts with this user name");
            if (namedAccounts == null)
                throw absence;
            if (!namedAccounts.Any())
                throw absence;

            return namedAccounts.First();
        }

        public AccountEntity[] ReadAll() => context.Accounts.ToArray();

        public void Update(string userName, AccountEntity entity)
        {
            AccountEntity account = Read(userName);
            int index = context.Accounts.IndexOf(account);
            context.Accounts[index] = entity;
        }
    }
}
