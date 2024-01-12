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
    public partial class DepartmentAdd : Form
    {
        private readonly List<DepartmentModel> departments;

        public DepartmentAdd(List<DepartmentModel> data) 
        {
            InitializeComponent();

            departments = data;
            
            AddBtn.Click += Add;
            CloseBtn.Click += Close;
        }
        
        readonly string isPattern = @"^[A-Z]{3}[0-9]{2,}$"; // 사원 코드, ID 정규식

        public void Add(object sender, EventArgs e)
        {
            string departmentId = IdText.Text;
            string departmentCode = CodeText.Text;
            string departmentName = NameText.Text;
            string memo = MemoText.Text;

            bool overlapId = departments.Any(d => d.부서ID == departmentId);
            bool overlapCode = departments.Any(d => d.부서코드 == departmentCode);

            if (overlapId || overlapCode)
            {
                MessageBox.Show("이미 존재하는 부서 ID 또는 부서 코드입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool checkPatternId = Regex.IsMatch(departmentId, isPattern);
            bool checkPatternCode = Regex.IsMatch(departmentCode, isPattern);

            if (!checkPatternId || !checkPatternCode)
            {
                MessageBox.Show("부서 ID, 부서코드의 형식이 올바르지 않습니다. \n[대문자3자 + 숫자2자이상]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(departmentId) || string.IsNullOrEmpty(departmentCode) || string.IsNullOrEmpty(departmentName))
            {
                MessageBox.Show("필수 입력 값을 입력해주세요.");
                return;
            }
            DepartmentModel newDepartment = new DepartmentModel
            {
                부서ID = departmentId,
                부서코드 = departmentCode,
                부서이름 = departmentName,
                메모 = memo
            };
            departments.Add(newDepartment);
            MessageBox.Show("새 부서가 추가되었습니다.");
            DialogResult = DialogResult.OK;
            Close();
        }

    public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
