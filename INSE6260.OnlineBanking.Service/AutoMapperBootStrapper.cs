using INSE6260.OnlineBanking.Infrastructure.Helpers;

using AutoMapper;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Model.Accounts;
using INSE6260.OnlineBanking.Service.ViewModels;

namespace INSE6260.OnlineBanking.Service
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Client, ClientView>();
            Mapper.CreateMap<Account, AccountView>();
        }
    }

   public class MoneyFormatter : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue is decimal)
            {
                var money = (decimal)context.SourceValue;

                return money.FormatMoney();
            }

            return context.SourceValue.ToString();
        }
    }

}
