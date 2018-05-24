using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Learningoutcomes
    {
        public string Learningoutcomesid { get; set; }
        public string Typeresultid { get; set; }
        public string Mshocsinh { get; set; }
        public string Schoolyearid { get; set; }
        public double? Mediumscore { get; set; }
        public string Conduct { get; set; }
        public string Grade { get; set; }

        public Student MshocsinhNavigation { get; set; }
        public Schoolyear Schoolyear { get; set; }
        public Typeresult Typeresult { get; set; }
    }
}
