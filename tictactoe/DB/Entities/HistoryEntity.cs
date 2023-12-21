using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe.DB.Entities
{
    internal class HistoryEntity
    {
        public string UserName { get; set; }
        public List<RecordEntity> History { get; set; }
    }
}
