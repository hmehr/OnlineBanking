using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using INSE6260.OnlineBanking.Model.Payee;

namespace INSE6260.OnlineBanking.Repository.EF.Mappings
{
    public class PayeeTypeConfiguration : EntityTypeConfiguration<Payee>
    {
        public PayeeTypeConfiguration()
        {
            HasKey(p => p.PayeeID);
            Property(d => d.NickName).HasMaxLength(50).IsRequired();
            Property(p => p.AccountNo).IsRequired();            
        }
    }
}
