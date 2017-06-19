using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Query
{
    public class UserQueryRepository
    {
        public Login  Login(User user)
        {
            DAL SP = new DAL("sp_User_LoginValidate");
            SP.AddParameter("@UserName", System.Data.SqlDbType.Text, user.userName);
            SP.AddParameter("@Password", System.Data.SqlDbType.Text, user.password);
            DataSet ds = SP.Execute();
            return new Login(user);
        }
    }
}
