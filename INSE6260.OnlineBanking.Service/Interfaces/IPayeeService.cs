using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INSE6260.OnlineBanking.Model.Payee;

namespace INSE6260.OnlineBanking.Service.Interfaces
{
    public interface IPayeeService
    {
        IList<Payee> GetAllPayee();
    }
}
