using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tictactoe.DB.Entities;
using tictactoe.DB.Repositories;
using tictactoe.DB.Services.Interfaces;
using TicTacToe;

namespace tictactoe.DB.Services
{
    internal class HistoryService : IHistoryService
    {
        private HistoryRepository historyRepository;
        public DBContext Context { get; set; }

        public HistoryService(DBContext context)
        {
            historyRepository = new HistoryRepository(context);

            this.Context = context;
        }

        public void AddHistory(string userName, GameHistory newHistory)
        {
            HistoryEntity historyEntity = historyRepository.Read(userName);

            RecordEntity recordEntity = new RecordEntity
            {
                GameID = newHistory.GameID,
                GameRating = newHistory.GameRating,
                GameResult = newHistory.GameResult,
                OpponentName = newHistory.OpponentName,
            };

            historyEntity.History.Add(recordEntity);
            historyRepository.Update(userName, historyEntity);
        }

        public List<GameHistory> GetHistory(string userName)
        {
            HistoryEntity historyEntity = historyRepository.Read(userName);
            List<RecordEntity> oldRecords = historyEntity.History;

            List<GameHistory> records = new List<GameHistory>();
            int n = oldRecords.Count;
            for (int i = 0; i < n; i++)
            {
                records.Add(new GameHistory(oldRecords[i].GameRating, oldRecords[i].OpponentName, oldRecords[i].GameResult, oldRecords[i].GameID));
            }

            return records;
        }

        public int GetRecordsCount(string userName)
        {
            HistoryEntity historyEntity = historyRepository.Read(userName);
            return historyEntity.History.Count;
        }

        public int GetRecordsCount(int id)
        {
            HistoryEntity historyEntity = historyRepository.Read(id);
            return historyEntity.History.Count;
        }
    }
}
