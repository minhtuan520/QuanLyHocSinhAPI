using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Student
    {
        public Student()
        {
            Learningoutcomes = new HashSet<Learningoutcomes>();
            Studentinclass = new HashSet<Studentinclass>();
            Testscores = new HashSet<Testscores>();
        }

        public string Mshocsinh { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public double? Sex { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Learningoutcomes> Learningoutcomes { get; set; }
        public ICollection<Studentinclass> Studentinclass { get; set; }
        public ICollection<Testscores> Testscores { get; set; }
    }
}
