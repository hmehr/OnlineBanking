using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INSE6260.OnlineBanking.Model.Payee;
using INSE6260.OnlineBanking.Infrastructure;

namespace INSE6260.OnlineBanking.Repository.EF.Repositories
{
    public class PayeeNameRepository : RepositoryBase<PayeeName>
    {
        public PayeeNameRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
