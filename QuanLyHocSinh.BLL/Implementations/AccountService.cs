using Microsoft.AspNetCore.Identity;
using QuanLyHocSinh.BLL.Contracts;
using QuanLyHocSinh.Common;
using QuanLyHocSinh.Common.AccountModels;
using QuanLyHocSinh.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.BLL.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly QuanLyHocSinhSqlContext _context;
        public AccountService()
        {
            _context = new QuanLyHocSinhSqlContext();
        }
        public QuanLyHocSinhResult<bool> SignIn(SignIn signInModel)
        {


            //MD5 encrypt = MD5.Create();         
            //byte[] inputBytes = Encoding.ASCII.GetBytes(signInModel.Password);           
            //byte[] hash = encrypt.ComputeHash(inputBytes);            
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < hash.Length; i++)
            //{
            //    sb.Append(hash[i].ToString("X2"));
            //}
            //string passMD5 = sb.ToString();
            //switch (signInModel.)
            //{
            //    default:
            //        break;
            //}
            //var findAccount = _context.Account.Where(acc => acc.Username == signInModel.UserName && acc.Password==passMD5)
            return null;
        }
    }
}
