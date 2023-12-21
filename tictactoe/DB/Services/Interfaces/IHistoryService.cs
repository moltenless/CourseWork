using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace tictactoe.DB.Services.Interfaces
{
    public interface IHistoryService
    {
        int GetRecordsCount(string userName);
        List<GameHistory> GetHistory(string userName);
        void AddHistory(string  userName, GameHistory newHistory);
    }
}
