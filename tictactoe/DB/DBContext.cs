using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tictactoe.DB.Entities;

namespace tictactoe.DB
{
    public class DBContext
    {
        public List<AccountEntity> Accounts { get; set; }
        public List<HistoryEntity> Histories { get; set; }

        public DBContext()
        {
            Accounts = new List<AccountEntity>();
            Histories = new List<HistoryEntity>();
        }

        public static DBContext GetDummyContext()
        {
            return new DBContext();
        }
    }
}
