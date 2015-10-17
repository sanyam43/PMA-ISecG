using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement.Model;
using ProjectManagement.BL;

namespace ProjectManagement.API
{
    public class UserController : ApiController
    {
        public IEnumerable<UserInfo> Get()
        {

            UserInfo[] ListOfUsers = UserBl.GetAllUsers();

            var users = from c in ListOfUsers
                           select c;


            return users.ToList();

        }
    }
}
