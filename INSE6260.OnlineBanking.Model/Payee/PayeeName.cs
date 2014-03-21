using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INSE6260.OnlineBanking.Model.Accounts;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Domain;

namespace INSE6260.OnlineBanking.Model.Payee
{
    public class PayeeName : EntityBase, IAggregateRoot
    {
        public int PayeeID { get; set; }
        public string Name { get; set; }
        public Account PayeeAccount { get; set; }
        public string AccountInstruction { get; set; }
    }
}
