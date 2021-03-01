using System;
using System.Collections.Generic;

#nullable disable

namespace BankApp.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
