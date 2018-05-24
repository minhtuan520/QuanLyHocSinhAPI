using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Typeaccount
    {
        public Typeaccount()
        {
            Account = new HashSet<Account>();
        }

        public double Idtype { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}
