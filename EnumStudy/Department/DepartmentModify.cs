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
    public partial class DepartmentModify : Form
    {
        private readonly List<DepartmentModel> departments = new List<DepartmentModel>();

        private DepartmentModel selectedDepartment;
     
        public DepartmentModify(List<DepartmentModel> data)
        {
            InitializeComponent();

            CloseBtn.Click += Close;
            ModifyBtn.Click += Modify;
            checkBtn.Click += IdCheck;

            departments.AddRange(data);
        }

        readonly string isPattern = @"^[A-Z]{3}[0-9]{2,}$"; // 부서 코드, ID 정규식

        public void IdCheck(object sender, EventArgs e)
        {
            string inputId = IdText.Text;

            selectedDepartment = departments.FirstOrDefault(d => d.부서ID == inputId);

            if (selectedDepartment != null) 
            {
                CodeText.Text = selectedDepartment.부서코드;
                NameText.Text = selectedDepartment.부서이름;
                MemoText.Text = selectedDepartment.메모;
            }
            else
            {
                MessageBox.Show("해당 ID의 부서가 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // 디버깅 메시지 추가
            Console.WriteLine($"inputId: {inputId}, selectedDepartment: {selectedDepartment}");
        }

        public void Modify(object sender, EventArgs e)
        {
            string departmentCode = CodeText.Text;
            string departmentName = NameText.Text;
            string memo = MemoText.Text;

            
            bool checkPatternCode = Regex.IsMatch(departmentCode, isPattern);

            if (!checkPatternCode)
            {
                MessageBox.Show("수정한 부서코드의 형식이 올바르지 않습니다. \n[대문자3자 + 숫자2자이상]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach(var department in departments)
            {
                if (department.부서ID == IdText.Text)
                {
                    department.부서코드 = departmentCode;
                    department.부서이름 = departmentName;
                    department.메모 = memo;
                    break;

                }
            }
            MessageBox.Show("성공적으로 수정 되었습니다.");
            DialogResult = DialogResult.OK;
            Close();
        }

        public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}

