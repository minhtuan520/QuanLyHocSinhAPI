using QuanLyHocSinh.DAL.Model;

namespace QuanLyHocSinh.DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(QuanLyHocSinhSqlContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
