using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tictactoe.DB.Entities;
using tictactoe.DB.Repositories.Interfaces;

namespace tictactoe.DB.Repositories
{
    internal class HistoryRepository : IRepository<HistoryEntity, string>
    {
        private DBContext context;

        public HistoryRepository(DBContext context)
        {
            this.context = context;
        }

        public void Create(HistoryEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("History Entity was null");
            context.Histories.Add(entity);
        }

        public void Delete(string userName)
        {
            HistoryEntity history = Read(userName);
            context.Histories.Remove(history);
        }

        public HistoryEntity Read(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException("Name was null");

            var namedHistories = context.Histories.Where((h) => h.UserName == userName);

            ArgumentException absence = new ArgumentException("There are not histories with this account's user name");
            if (namedHistories == null)
                throw absence;
            if (!namedHistories.Any())
                throw absence;

            return namedHistories.First();
        }

        public void Update(string userName, HistoryEntity entity)
        {
            HistoryEntity history = Read(userName);
            int index = context.Histories.IndexOf(history);
            context.Histories[index] = entity;
        }
    }
}
