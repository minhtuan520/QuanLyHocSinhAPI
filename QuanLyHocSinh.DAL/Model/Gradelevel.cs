using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Gradelevel
    {
        public Gradelevel()
        {
            Class = new HashSet<Class>();
        }

        public double Gradelevelid { get; set; }
        public string Name { get; set; }

        public ICollection<Class> Class { get; set; }
    }
}
