using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INSE6260.OnlineBanking.Model.Payee;
using System.Data.Entity.ModelConfiguration;

namespace INSE6260.OnlineBanking.Repository.EF.Mappings
{
    public class PayeeNameTypeConfiguration: EntityTypeConfiguration<PayeeName>
    {

        public PayeeNameTypeConfiguration()
        {
            HasKey(pn=>pn.PayeeID);
            Property(d => d.Name).IsRequired().HasMaxLength(50);
            
        }
                
    }
}
