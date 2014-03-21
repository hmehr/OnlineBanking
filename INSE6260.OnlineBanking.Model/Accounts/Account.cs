using System;
using System.Collections.Generic;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Domain;

namespace INSE6260.OnlineBanking.Model.Accounts
{
    public class Account : EntityBase, IAggregateRoot
    {
        public int AccountID { get; set; }
        public DateTime OpendedDate { get; set; }
        public virtual Client Client { get; set; }
        public double Balance { get; set; }
        public virtual ICollection<ClientCard.ClientCard> ClientCards { get; set; }
    }
}
