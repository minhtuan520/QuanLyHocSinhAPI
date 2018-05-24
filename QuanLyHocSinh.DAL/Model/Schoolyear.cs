using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Schoolyear
    {
        public Schoolyear()
        {
            Learningoutcomes = new HashSet<Learningoutcomes>();
            Studentinclass = new HashSet<Studentinclass>();
            Testscores = new HashSet<Testscores>();
        }

        public string Schoolyearid { get; set; }
        public string Name { get; set; }

        public ICollection<Learningoutcomes> Learningoutcomes { get; set; }
        public ICollection<Studentinclass> Studentinclass { get; set; }
        public ICollection<Testscores> Testscores { get; set; }
    }
}
