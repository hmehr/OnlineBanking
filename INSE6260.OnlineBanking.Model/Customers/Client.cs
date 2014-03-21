using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Domain;
using INSE6260.OnlineBanking.Model.Accounts;

namespace INSE6260.OnlineBanking.Model
{
    public class Client : EntityBase, IAggregateRoot
    {
        public Int32 ClientID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer Name can not be null.")]
        [StringLength(50)]
        public String Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer Family can not be null.")]
        [StringLength(50)]
        public String Family { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public virtual IList<Account> Accounts { get; set; }

        protected override void Validate()
        {
            if(Name == Family) AddBrokenRule(new BusinessRule(@"Name","Name and Family can not be equal."));
        }
        
    }
}
