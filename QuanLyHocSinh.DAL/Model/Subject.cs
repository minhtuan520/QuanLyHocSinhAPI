using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class Subject
    {
        public Subject()
        {
            Testscores = new HashSet<Testscores>();
        }

        public string Subjectid { get; set; }
        public string Name { get; set; }

        public ICollection<Testscores> Testscores { get; set; }
    }
}
