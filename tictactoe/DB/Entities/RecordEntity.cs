using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe.DB.Entities
{
    public class RecordEntity
    {
        public int GameRating { get; set; }
        public string OpponentName { get; set; }
        public string GameResult { get; set; }
        public int GameID { get; set; }
    }
}
