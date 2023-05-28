using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLNS
{
    public partial class Login : Form
    {
        //string Username = "admin";
        //string Password = "admin";

        List<User> listUsers = UserList.Instance.ListUser;

        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            panel3.BackColor = Color.White;
            txtPassword.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            panel4.BackColor = Color.White;
            txtUsername.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
            
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false; 
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (checkAccount(txtUsername.Text,txtPassword.Text))
            {
                Main f = new Main();
                f.Show();
                this.Hide();
                f.Logout += F_Logout;
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu ! ", "ERROR ");
                txtUsername.Clear();
                txtPassword.Clear();
            }
            


        }

        private void F_Logout(object sender, EventArgs e)
        {
            (sender as Main).isExit = false;
            (sender as Main).Close();
            this.Show();
           
        }

        bool checkAccount(string Usernamne, string Password )
        {
            for (int i = 0; i < listUsers.Count; i++)
            {
                if (Usernamne == listUsers[i].UserName && Password == listUsers[i].PassWord)
                {
                    return true;
                }
            }

            return false;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
