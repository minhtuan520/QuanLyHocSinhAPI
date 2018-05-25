using QuanLyHocSinh.Common;
using QuanLyHocSinh.Common.AccountModels;
using System.Threading.Tasks;

namespace QuanLyHocSinh.BLL.Contracts
{
    public interface IAccountService
    {
        QuanLyHocSinhResult<bool> SignIn(SignIn signInModel);
    }
}
