using System;
using System.Collections.Generic;

#nullable disable

namespace BankApp.Models
{
    public partial class Account
    {
        public int UserPkid { get; set; }
        public string CheckingNumber { get; set; }
        public decimal Balance { get; set; }

        public virtual User UserPk { get; set; }
    }
}
