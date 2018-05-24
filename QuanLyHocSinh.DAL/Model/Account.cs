using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public double? Idtype { get; set; }

        public Typeaccount IdtypeNavigation { get; set; }
    }
}
