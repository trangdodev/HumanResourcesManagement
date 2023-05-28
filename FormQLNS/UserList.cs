using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormQLNS
{
    internal class UserList
    {
        private static UserList instance;

        internal static UserList Instance 
        { 
            get
            { 
                if (instance == null)
                    instance = new UserList();
                return instance; 
            } 
                        
           set => instance = value; }

        List<User> listUser;

        internal List<User> ListUser { get => listUser; set => listUser = value; }
        

        UserList()
        {
            listUser = new List<User>();
            listUser.Add(new User("admin", "admin"));
            listUser.Add(new User("dominators", "dominators"));
        }
    }
}
