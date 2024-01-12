using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumStudy
{
    public partial class DepartmentDelete : Form
    {
        private string selectedCode;
        private string selectedName;
        public DepartmentDelete(string code, string name)
        {
            InitializeComponent();
            DeleteBtn.Click += Delete;
            CloseBtn.Click += Close;


            // code와 name을 각각의 변수에 할당한다.
            selectedCode = code;
            selectedName = name;

            CodeLabel.Text = "부서 코드 : " + selectedCode;
            NameLabel.Text = "부서 명 : " + selectedName;
        }

        
        public void Delete(object sender, EventArgs e)
        {
            // DataManager를 통해 선택된 부서 삭제
            DataManager.Instance.Departments.RemoveAll(d => d.부서코드 == selectedCode);

            MessageBox.Show("부서가 성공적으로 삭제되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
