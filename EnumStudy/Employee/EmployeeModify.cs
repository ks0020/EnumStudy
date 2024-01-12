using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumStudy
{
    public partial class EmployeeModify : Form
    {
        public EmployeeModify()
        {
            InitializeComponent();
            ModifyBtn.Click += Modify;
            CloseBtn.Click += Close;
            checkBtn.Click += IdCheck;

            LoadDepartmentCodes();

            CodeCombo.SelectedIndex = -1;
            CodeCombo.SelectedIndexChanged += SelectDepartmentName;
        }
        readonly string isPattern = @"^[A-Z]{3}[0-9]{2,}$";

        private void LoadDepartmentCodes()
        {
            // DataManager에서 부서 코드 목록을 가져옴
            List<string> departmentCodes = DataManager.Instance.Departments.Select(d => d.부서코드).ToList();

            // 부서 코드를 CodeCombo 콤보박스에 추가
            CodeCombo.DataSource = departmentCodes;
        }

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

        public void IdCheck(object sender, EventArgs e)
        {
            string inputId = idText.Text;

            EmployeeModel selectUser = DataManager.Instance.Employees.FirstOrDefault(d => d.로그인ID == inputId);

            if (selectUser != null) 
            {
                CodeCombo.SelectedItem = selectUser.부서코드;
                DepartmentNameText.Text = selectUser.부서이름;
                EmployeeCodeText.Text = selectUser.사원코드;
                EmployeeNameText.Text = selectUser.사원이름;
                PositionText.Text = selectUser.직위;
                TypeText.Text = selectUser.고용형태;
                ContactText.Text = selectUser.연락처;
                EmailText.Text = selectUser.이메일;
                MessengerText.Text = selectUser.메신저ID;
                MemoText.Text = selectUser.메모;
            } else
            {
                MessageBox.Show("해당 ID의 사원이 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modify(object sender, EventArgs e)
        {
            string inputEmployeeCode = EmployeeCodeText.Text;

            bool checkPatternCode = Regex.IsMatch(inputEmployeeCode, isPattern);
            if (!checkPatternCode)
            {
                MessageBox.Show("수정한 사원코드의 형식이 올바르지 않습니다. \n[대문자3자 + 숫자2자이상]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string inputId = idText.Text;
            EmployeeModel selectUser = DataManager.Instance.Employees.FirstOrDefault(d => d.로그인ID == inputId);
            if (selectUser != null)
            {
                selectUser.부서코드 = CodeCombo.Text;
                selectUser.부서이름 = DepartmentNameText.Text;
                selectUser.사원코드 = inputEmployeeCode;
                selectUser.사원이름 = EmployeeNameText.Text;
                selectUser.직위 = PositionText.Text;
                selectUser.고용형태 = TypeText.Text;
                selectUser.연락처 = ContactText.Text;
                selectUser.이메일 = EmailText.Text;
                selectUser.메신저ID = MessengerText.Text;
                selectUser.메모 = MemoText.Text;
                MessageBox.Show("성공적으로 수정 되었습니다.");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
