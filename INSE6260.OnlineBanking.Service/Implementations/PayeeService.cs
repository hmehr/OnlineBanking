using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INSE6260.OnlineBanking.Service.Interfaces;
using INSE6260.OnlineBanking.Model.Payee;
using INSE6260.OnlineBanking.Infrastructure;

namespace INSE6260.OnlineBanking.Service.Implementations
{
    public class PayeeService:IPayeeService
    {
        private readonly IPayeeRepository _payeeRepository;
        private readonly IUnitOfWork _uow;

        public PayeeService(IPayeeRepository payeeRepository, IUnitOfWork uow)
        {
            _payeeRepository = payeeRepository;
            _uow = uow;
        }
        public IList<Model.Payee.Payee> GetAllPayee()
        {
            return _payeeRepository.GetAll().ToList();
        }
    }
}
