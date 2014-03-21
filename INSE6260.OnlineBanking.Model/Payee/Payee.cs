using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Domain;

namespace INSE6260.OnlineBanking.Model.Payee
{
    public class Payee : EntityBase, IAggregateRoot
    {
        public int PayeeID { get; set; }
        public string NickName { get; set; }
        public PayeeName PayeeName { get; set; }
        public int AccountNo { get; set; }
    }
}
