using System;
using System.ComponentModel.DataAnnotations;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Domain;
using INSE6260.OnlineBanking.Model.Accounts;

namespace INSE6260.OnlineBanking.Model.ClientCard
{
    public class ClientCard : EntityBase, IAggregateRoot
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Card ID can not be null.")]
        [StringLength(16)]
        [RegularExpression("^4[0-9]{12}(?:[0-9]{3})?$", ErrorMessage = "Card ID is icorrect.")]
        public string CardID { get; set; }

        public string Password { get; set; }

        public DateTime ExpirationDate { get; set; }

        public String SecurityCode { get; set; }

        public string SecurityQuestion1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityQuestion3 { get; set; }
        public string SecurityAnswer1   { get; set; }
        public string SecurityAnswer2   { get; set; }
        public string SecurityAnswer3   { get; set; }

        public virtual Account CardAccount { get; set; }
    }
}
