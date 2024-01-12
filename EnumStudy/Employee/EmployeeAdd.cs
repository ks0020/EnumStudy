using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumStudy
{
    public partial class EmployeeAdd : Form
    {
        public EmployeeAdd()
        {
            InitializeComponent();
            AddBtn.Click += Add;
            CloseBtn.Click += Close;
            LoadDepartmentCodes();

            CodeCombo.SelectedIndex = -1;
            CodeCombo.SelectedIndexChanged += SelectDepartmentName;
        }
        readonly string isPattern = @"^[A-Z]{3}[0-9]{2,}$";

        /// <summary>
        /// 콤보박스 코드추가
        /// </summary>
        private void LoadDepartmentCodes()
        {
            // DataManager에서 부서 코드 목록을 가져옴
            List<string> departmentCodes = DataManager.Instance.Departments.Select(d => d.부서코드).ToList();

            // 부서 코드를 CodeCombo 콤보박스에 추가
            CodeCombo.DataSource = departmentCodes;
        }
        /// <summary>
        /// 코드에 맞는 이름 찾기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDepartmentName(object sender, EventArgs e)
        {
            string selectCode = CodeCombo.SelectedItem?.ToString();

            DepartmentModel selectDepartmentName = DataManager.Instance.Departments.FirstOrDefault(d => d.부서코드 == selectCode);
            if (selectDepartmentName != null) 
            {
                DepartmentNameText.Text = selectDepartmentName.부서이름;
            }
            else 
            {
                DepartmentNameText.Text = string.Empty;
            }
        }

        private bool EmailCheck(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch 
            {

                throw;
            }
        }
        private string HashPassword(string passowrd)
        {
            using (SHA256 sha256Hash = SHA256.Create()) 
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(passowrd));
                StringBuilder sBuilder = new StringBuilder();
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    sBuilder.Append(bytes[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        

        public void Add(object sender, EventArgs e)
        {
            string DepartmentCode = CodeCombo.Text;
            string EmployeeCode = EmployeeCodeText.Text;
            string EmployeeName = EmployeeNameText.Text;
            string UserId = UserIdText.Text;

            if (string.IsNullOrEmpty(DepartmentCode) || string.IsNullOrEmpty(EmployeeCode) || string.IsNullOrEmpty(EmployeeName) || string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(UserPasswordText.Text))
            {
                MessageBox.Show("필수 정보를 입력 해주세요..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EmailText.Text != "")
            {
                if (string.IsNullOrEmpty(EmailText.Text) || !EmailCheck(EmailText.Text))
                {
                    MessageBox.Show("올바른 이메일 주소 형식이 아닙니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bool checkPatternCode = Regex.IsMatch(EmployeeCode, isPattern);

            if (!checkPatternCode)
            {
                MessageBox.Show("사원코드의 형식이 올바르지 않습니다. \n[대문자3자 + 숫자2자이상]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 사원코드체크
            EmployeeModel overlapECode = DataManager.Instance.Employees.FirstOrDefault(d => d.사원코드 == EmployeeCode);
            if (overlapECode != null)
            {
                MessageBox.Show("이미 존재하는 사원코드입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 아이디체크
            EmployeeModel overlapId = DataManager.Instance.Employees.FirstOrDefault(d => d.로그인ID == UserId);
            if (overlapId != null)
            {
                MessageBox.Show("이미 존재하는 아이디입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 비밀번호 해싱
            string hashedPassword = HashPassword(UserPasswordText.Text);

            // 비밀번호 유효성 검사
            if (UserPasswordText.Text.Length < 8 || !Regex.IsMatch(UserPasswordText.Text, @"^(?=.*[a-zA-Z])(?=.*[0-9]).{8,}$"))
            {
                MessageBox.Show("비밀번호는 8자 이상이어야 하며, 영문과 숫자를 혼용하여야 합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EmployeeModel newEmployee= new EmployeeModel
            {
                부서코드 = DepartmentCode,
                부서이름 = DepartmentNameText.Text,
                사원코드 = EmployeeCode,
                사원이름 = EmployeeName,
                로그인ID = UserId,
                비밀번호 = hashedPassword,
                직위 = PositionText.Text,
                고용형태 = TypeText.Text,
                연락처 = ContactText.Text,
                이메일 = EmailText.Text,
                메신저ID = MessengerText.Text,
                메모 = MemoText.Text
            };
            DataManager.Instance.Employees.Add(newEmployee);
            MessageBox.Show("새 사원이 추가되었습니다.");
            DialogResult = DialogResult.OK;
            Close();
        }

        public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
