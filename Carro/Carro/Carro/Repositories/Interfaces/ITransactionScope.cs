using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carro.Repositories.Interfaces
{
    public interface ITransactionScope
    {
        string BeginTransaction();
        void EndTransaction(string savePointId);
        void RollBack(string savePointId);
        void Complete();
    }
}