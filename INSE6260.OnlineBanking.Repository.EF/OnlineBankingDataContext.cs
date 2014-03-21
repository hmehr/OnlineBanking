using System.Data.Entity;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Model.Accounts;
using INSE6260.OnlineBanking.Model.ClientCard;
using INSE6260.OnlineBanking.Repository.EF.Mappings;
using INSE6260.OnlineBanking.Model.Payee;

namespace INSE6260.OnlineBanking.Repository.EF
{
    public class OnlineBankingDataContext : DbContext
    {
        public OnlineBankingDataContext(string connectionName): base(connectionName)
        {
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OnlineBankingDataContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientTypeConfiguration());
            modelBuilder.Configurations.Add(new AccountTypeConfiguration());
            modelBuilder.Configurations.Add(new ClientCardTypeConfiguration());
            modelBuilder.Configurations.Add(new PayeeTypeConfiguration());
            modelBuilder.Configurations.Add(new PayeeNameTypeConfiguration());
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientCard> ClientCards { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<PayeeName> PayeeNames { get; set; }

        public DbSet<Payee> Payees { get; set; }       
       
    }
}