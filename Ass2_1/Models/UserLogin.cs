using Ass2_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    public class UserLogin
    {
        public User Login(string userName, string password)
        {
            DataBaseAccess dal = new DataBaseAccess();
            User user = dal.GetUser(userName);
            if (user != null)
            {
                Security secure = new Security();
                if (secure.VerifyHash(password, user.pass))
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUser(User user)
        {
            Security secure = new Security();
            user.pass = secure.HashSHA1(user.pass);
            DataBaseAccess dal = new DataBaseAccess();
            dal.AddUser(user);
        }
        public void populate()
        {
           
            User u1 = new User();
            u1.idUser = 1;
            u1.name = "diana";
            u1.pass = "client";
            u1.tip = "c";
            AddUser(u1);
            User u2 = new User();
            u2.idUser = 2;
            u2.name = "anca";
            u2.pass = "admin";
            u2.tip = "a";
            AddUser(u2);
        }
    }
}
