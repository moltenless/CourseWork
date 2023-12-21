using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tictactoe.Account;
using tictactoe.DB.Entities;
using tictactoe.DB.Repositories;
using tictactoe.DB.Services.Interfaces;
using TicTacToe;

namespace tictactoe.DB.Services
{
    public class DataService : IAccountService, IHistoryService
    {
        private AccountRepository accountsRepository;
        private HistoryRepository historyRepository;

        public DataService(DBContext context)
        {
            accountsRepository = new AccountRepository(context);
            historyRepository = new HistoryRepository(context);
        }

        public void AddAccount(PlayerAccount newAccount)
        {
            AccountEntity account = new AccountEntity
            {
                NumberOfGames = newAccount.NumberOfGames,
                Rating = newAccount.Rating,
                UserName = newAccount.UserName,
            };

            accountsRepository.Create(account);
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

            HistoryEntity history = historyRepository.Read(userName);
            for (int i = 0; i < history.History.Count; i++)
            {
                RecordEntity record = history.History[i];
                GameHistory gameHistory = new GameHistory(record.GameRating, record.OpponentName, record.GameResult);
                player.History.Add(gameHistory);
            }

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

            HistoryEntity history = historyRepository.Read(account.UserName);
            for (int i = 0; i < history.History.Count; i++)
            {
                RecordEntity record = history.History[i];
                GameHistory gameHistory = new GameHistory(record.GameRating, record.OpponentName, record.GameResult);
                player.History.Add(gameHistory);
            }

            return player;
        }

        public int GetAccountsCount() => accountsRepository.ReadAll().Length;

        public PlayerAccount[] GetAllAccounts()
        {
            AccountEntity[] old = accountsRepository.ReadAll();
            PlayerAccount[] accounts = new PlayerAccount[GetAccountsCount()];
            for (int i = 0; i <  accounts.Length; i++)
            {
                accounts[i] = GetAccount(old[i].UserName);
            }
            return accounts;
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

        public GameHistory[] GetHistory(string userName)
        {
            HistoryEntity historyEntity = historyRepository.Read(userName);
            RecordEntity[] oldRecords = historyEntity.History.ToArray();

            GameHistory[] records = new GameHistory[oldRecords.Length];
            for (int i = 0; i < records.Length; i++)
            {
                records[i] = new GameHistory(oldRecords[i].GameRating, oldRecords[i].OpponentName, oldRecords[i].GameResult);
            }

            return records;
        }

        public int GetRecordsCount(string userName)
        {
            HistoryEntity historyEntity = historyRepository.Read(userName);
            return historyEntity.History.Count;
        }
    }
}