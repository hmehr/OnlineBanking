using System.Data.Entity.ModelConfiguration;
using INSE6260.OnlineBanking.Model;

namespace INSE6260.OnlineBanking.Repository.EF.Mappings
{
    public class ClientTypeConfiguration : EntityTypeConfiguration<Client>
    {
        
        public ClientTypeConfiguration()
        {
            HasKey(cust => cust.ClientID);
            Property(d => d.Name).IsRequired().HasMaxLength(50);
            Property(d => d.Family).IsRequired().HasMaxLength(50);
            Property(d => d.Email).IsOptional().HasMaxLength(50);
            HasMany(c => c.Accounts).WithRequired(t => t.Client).Map(m=>m.MapKey("ClientID"));
        }
                
    }
}
