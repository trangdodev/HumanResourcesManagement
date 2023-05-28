using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormQLNS
{
    internal class User
    {
        private string userName;
        private string passWord;
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }

        public User()
        {
            
        }

        public User(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        
    }
}
