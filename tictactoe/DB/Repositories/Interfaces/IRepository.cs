using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe.DB.Repositories.Interfaces
{
    internal interface IRepository<T, Tsearch>
    {
        void Create(T entity);
        T Read(Tsearch identifier);
        void Update(Tsearch identifier, T entity);
        void Delete(Tsearch identifier);
    }
}
