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
    public partial class EmployeeDelete : Form
    {
        private readonly string selectCode;
        private readonly string selectName;
        public EmployeeDelete(string code, string name)
        {
            InitializeComponent();
            DeleteBtn.Click += Delete;
            CloseBtn.Click += Close;

            selectCode = code;
            selectName = name;

            CodeLabel.Text = "사원 코드 : " + selectCode;
            NameLabel.Text = "사원 이름 : " + selectName;

        }

        public void Delete(object sender, EventArgs e)
        {
            Console.WriteLine(selectCode);
            if(selectCode != null)
            {
                DataManager.Instance.Employees.RemoveAll(d => d.사원코드 == selectCode);

                MessageBox.Show("성공적으로 삭제되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    