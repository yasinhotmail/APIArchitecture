using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Query;

namespace Manager.Query
{
    public class UserQueryManager
    {
        public Login Login(User user)
        {
            UserQueryRepository userRepo = new UserQueryRepository();

            return userRepo.Login(user);
        
        }
    }
}
