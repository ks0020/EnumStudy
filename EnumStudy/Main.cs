using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumStudy.Login;

namespace EnumStudy
{
    public partial class Main : Form
    {
        public List<EmployeeModel> employees = new List<EmployeeModel>();
        public List<DepartmentModel> departments = new List<DepartmentModel>();
        // 모델 형식의 요소를 저장할 수 있게 각각의 이름의 List를 생성한다. 각 List에는 각각의 모델 객체의 목록을 저장하며, 각각의 객체는 부서 / 사원의 관한 정보를 담고 있다. 
        public Main()
        {
            InitializeComponent();

            DepartmentLabel.Click += Department;
            RefreshLabel.Click += Refresh;
            AddLabel.Click += Add;
            ModifyLabel.Click += Modify;
            LoginLabel.Click += Login;
            DeleteLabel.Click += Delete;
            CloseBtn.Click += Close;

            EmployeeList.DataSource = employees;
            EmployeeList.CellFormatting += PasswordBlind;
        }

        private void PasswordBlind(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && EmployeeList.Columns[e.ColumnIndex].Name == "비밀번호")
            {
                if (e.Value != null)
                {
                    string PBlind = new string('*', 8); // 비밀번호를 무조건 8자리 '*'로 블러처리

                    e.Value = PBlind;
                }
            }
        }

        public void Department(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                Department department = new Department();
                department.Show();
            }
            else
            {
                MessageBox.Show("로그인이 필요합니다. 로그인 후에 서비스를 이용해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Refresh(object sender, EventArgs e)
        {
            // 그리드뷰의 데이터 소스를 다시 설정
            EmployeeList.DataSource = null; 
            EmployeeList.DataSource = DataManager.Instance.Employees;

            // 그리드뷰를 다시 그리도록 강제로 호출
            EmployeeList.Refresh();
            MessageBox.Show("새로고침 성공!");
        }

        public void Add(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                EmployeeAdd eAdd = new EmployeeAdd();
                var result = eAdd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshEmployeeList();
                }
            }
            else
            {
                MessageBox.Show("로그인이 필요합니다. 로그인 후에 서비스를 이용해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modify(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                EmployeeModify eModify = new EmployeeModify();
                var result = eModify.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshEmployeeList();
                }
            }
            else
            {
                MessageBox.Show("로그인이 필요합니다. 로그인 후에 서비스를 이용해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Login(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                string welcomeMessage = $"안녕히 가세요, {Session.UserName} 님!";
                MessageBox.Show(welcomeMessage, "로그아웃", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Session.Logout();
                LoginLogout();
            }
            else
            {

                // 로그인 폼을 띄워 로그인 처리
                Login loginForm = new Login();
                loginForm.ShowDialog();

                // 로그인 폼에서 로그인 성공하면 세션에 정보가 업데이트되므로 다시 버튼 라벨 업데이트
                LoginLogout();
            }
        }
        private void LoginLogout()
        {
            if (Session.IsLoggedIn)
            {
                LoginLabel.Text = "로그아웃";
            }
            else
            {
                LoginLabel.Text = "로그인 정보";
            }
        }

        private readonly int selectedRowIndex = 0;
        public void Delete(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                string selectedCode = "";
                string selectedName = "";
                if (selectedRowIndex >= 0)
                {
                    selectedCode = EmployeeList.Rows[selectedRowIndex].Cells["사원코드"].Value?.ToString();
                    selectedName = EmployeeList.Rows[selectedRowIndex].Cells["사원이름"].Value?.ToString();

                }
                EmployeeDelete eDelete = new EmployeeDelete(selectedCode, selectedName);
                var result = eDelete.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RefreshEmployeeList();
                }

            }
            else
            {
                MessageBox.Show("로그인이 필요합니다. 로그인 후에 서비스를 이용해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshEmployeeList()
        {
            // 그리드뷰의 데이터 소스를 다시 설정
            EmployeeList.DataSource = null;
            EmployeeList.DataSource = DataManager.Instance.Employees;

            // 그리드뷰를 다시 그리도록 강제로 호출
            EmployeeList.Refresh();
        }

        public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
