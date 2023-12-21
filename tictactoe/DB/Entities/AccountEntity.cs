using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe.DB.Entities
{
    public class AccountEntity
    {
        public string UserName { get; set; }
        public int Rating { get; set; }
        public int NumberOfGames { get; set; }
    }
}
