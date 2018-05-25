using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyHocSinh.Common.AccountModels
{
    public class SignIn
    {
        [Required, Range(5,20)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IdType { get; set; }
    }
}
