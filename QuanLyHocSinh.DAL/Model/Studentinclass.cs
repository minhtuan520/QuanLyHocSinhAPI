using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Studentinclass
    {
        public string Schoolyearid { get; set; }
        public string Idclass { get; set; }
        public string Mshocsinh { get; set; }

        public Class IdclassNavigation { get; set; }
        public Student MshocsinhNavigation { get; set; }
        public Schoolyear Schoolyear { get; set; }
    }
}
