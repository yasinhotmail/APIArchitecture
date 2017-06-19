using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Login :User
    {
        [DataMember]
        public DateTime LoggedInTime { get; set; }
        [DataMember]
        public bool LoginSuccess { get; set; }

        public Login(User user){
            userName = user.userName;
            password = user.password;
        }
    }
}
