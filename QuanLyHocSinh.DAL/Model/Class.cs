using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Class
    {
        public Class()
        {
            Studentinclass = new HashSet<Studentinclass>();
        }

        public string Idclass { get; set; }
        public double? Gradelevelid { get; set; }
        public string Name { get; set; }

        public Gradelevel Gradelevel { get; set; }
        public ICollection<Studentinclass> Studentinclass { get; set; }
    }
}
