using ProjectManagement.DAL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.BL
{
    public class UserBl
    {
        public static UserInfo[] GetAllUsers()
        {
            UserInfo[] userInfo = UserDal.GetAllUsers();
            return userInfo;

        }
    }
}
