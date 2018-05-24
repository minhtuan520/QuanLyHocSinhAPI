using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Testscores
    {
        public string Subjectid { get; set; }
        public double Semesterid { get; set; }
        public string Schoolyearid { get; set; }
        public string Mshocsinh { get; set; }
        public double? Score5m { get; set; }
        public double? Score15m { get; set; }
        public double? Score45m { get; set; }
        public double? ScoreMidyear { get; set; }
        public double? ScoreEndyear { get; set; }

        public Student MshocsinhNavigation { get; set; }
        public Schoolyear Schoolyear { get; set; }
        public Semester Semester { get; set; }
        public Subject Subject { get; set; }
    }
}
