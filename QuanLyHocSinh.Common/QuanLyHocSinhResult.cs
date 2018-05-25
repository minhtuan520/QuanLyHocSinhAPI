using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyHocSinh.Common
{
    public class QuanLyHocSinhResult<T>
    {
        public bool Succeed { get; set; }
        public T Content { get; set; }
        public Dictionary<int, string> Errors { get; set; }
    }
}
