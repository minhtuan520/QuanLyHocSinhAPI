using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Semester
    {
        public Semester()
        {
            Testscores = new HashSet<Testscores>();
        }

        public double Semesterid { get; set; }
        public string Name { get; set; }
        public double? Coefficient { get; set; }

        public ICollection<Testscores> Testscores { get; set; }
    }
}
