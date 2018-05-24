using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Typeresult
    {
        public Typeresult()
        {
            Learningoutcomes = new HashSet<Learningoutcomes>();
        }

        public string Typeresultid { get; set; }
        public string Name { get; set; }

        public ICollection<Learningoutcomes> Learningoutcomes { get; set; }
    }
}
