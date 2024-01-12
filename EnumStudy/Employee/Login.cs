using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumStudy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            LoginBtn.Click += LoginInfo;
            CloseBtn.Click += Close;

        }

        // 비밀번호 해시
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder Sbuild = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    Sbuild.Append(bytes[i].ToString("x2"));
                }
                return Sbuild.ToString();
            }
        }

        public void LoginInfo(object sender, EventArgs e)
        {
            string idText = UserId.Text;
            string passwordText = UserPassword.Text;

            EmployeeModel userInfo = DataManager.Instance.Employees.FirstOrDefault(employee => employee.로그인ID == idText);

            if (userInfo != null)
            {
                string hashedEnteredPassword = HashPassword(passwordText);

                if (hashedEnteredPassword == userInfo.비밀번호)
                {
                    Session.Login(userInfo.로그인ID, userInfo.사원이름);

                    MessageBox.Show($"로그인 성공! {userInfo.사원이름}님 환영합니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("비밀번호가 올바르지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("존재하지 않는 아이디입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class Session 
        {
            public static bool IsLoggedIn 
            {
                get; private set; 
            }
            public static string UserId 
            {
                get; private set;
            }
            public static string UserName { get; private set; } 

            public static void Login(string userId, string userName)
            {
                IsLoggedIn = true;
                UserId = userId;
                UserName = userName;
            }

            public static void Logout()
            {
                IsLoggedIn = false;
                UserId = null;
                UserName = null;
            }
        }

        public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
