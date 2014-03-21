﻿using System.Data.Entity.ModelConfiguration;
using INSE6260.OnlineBanking.Model.Accounts;

namespace INSE6260.OnlineBanking.Repository.EF.Mappings
{
    public class AccountTypeConfiguration : EntityTypeConfiguration<Account>
    {

        public AccountTypeConfiguration()
        {
            HasKey(cust => cust.AccountID);
            Property(d => d.Balance).IsRequired();
            HasMany(acc=>acc.ClientCards).WithRequired(t => t.CardAccount).Map(m=>m.MapKey("AccountID"));
        }
    }
}
