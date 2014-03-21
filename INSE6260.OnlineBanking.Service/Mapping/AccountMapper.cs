using AutoMapper;
using INSE6260.OnlineBanking.Model.Accounts;
using INSE6260.OnlineBanking.Service.ViewModels;

namespace INSE6260.OnlineBanking.Service.Mapping
{
    public static class AccountMapper
    {
        public static AccountView ConvertToAccountView(this Account account)
        {
            return Mapper.Map<Account, AccountView>(account);
        }
    }
}
