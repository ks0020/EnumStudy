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
    public partial class Department : Form
    {
        private readonly List<DepartmentModel> departments;
        private BindingList<DepartmentModel> departmentsBindingList = new BindingList<DepartmentModel>();
        // 새로고침 과정에서 바인딩할때 초기화하는 부분
        // DataGridView가 변경되었을때 이를 인식못해서 오류발생할수 있기때문에 필요
        
        public Department()
        {
            InitializeComponent();

            closeBtn.Click += Close;
            AddBtn.Click += Add;
            ModifyBtn.Click += Modify;
            DeleteBtn.Click += Delete;


            // 바인딩
            departments = DataManager.Instance.Departments;

            // List<DepartmentModel>에 있는 객체에서 부서코드, 부서이름, 메모만 선택하여 리스트에 저장
            var selectedDepartments = departments
                .Select(d => new { 부서코드 = d.부서코드, 부서이름 = d.부서이름, 메모 = d.메모 })
                .ToList();
            // Linq쿼리를 사용하여 departments리스트에서 필요한 속성만 선택하여 새로운 객체를 생성한다.
            // ToList()를 호출하여 Linq쿼리 결과를 리스트로 변환 한다. 

            // DepartmentList에 데이터 소스 설정
            DepartmentList.DataSource = selectedDepartments;
        }
        
        public void Add(object sender, EventArgs e)
        {
            DepartmentAdd dAdd = new DepartmentAdd(departments);
            var result = dAdd.ShowDialog();

            // DepartmentAdd 폼에서 DialogResult가 OK로 설정되면 데이터를 새로 고침
            if (result == DialogResult.OK)
            {
                RefreshDepartmentData();
            }
        }
  
        public void Modify(object sender, EventArgs e)
        {
            DepartmentModify dModify = new DepartmentModify(departments);
            var result = dModify.ShowDialog();

            if (result == DialogResult.OK)
            {
                RefreshDepartmentData();
            }
        }

        private int selectedRowIndex = 0;
        public void Delete(object sender, EventArgs e)
        {
            string selectedCode = "";
            string selectedName = "";
            if (selectedRowIndex >= 0)
            {
                selectedCode = DepartmentList.Rows[selectedRowIndex].Cells["부서코드"].Value?.ToString();
                selectedName = DepartmentList.Rows[selectedRowIndex].Cells["부서이름"].Value?.ToString();

            }
            DepartmentDelete dDelete = new DepartmentDelete(selectedCode, selectedName);
            var result = dDelete.ShowDialog();

            if (result == DialogResult.OK)
            {
                RefreshDepartmentData();
            }
        }

        //새로고침
        private void RefreshDepartmentData()
        {
            // DataGridView 등을 업데이트하는 코드 작성
            foreach (var department in departments)
            {
                departmentsBindingList.Add(department);
            }

            // BindingList<DepartmentModel>에 있는 객체에서 부서코드, 부서이름, 메모만 선택하여 리스트에 저장
            var selectedDepartments = departments
                .Select(d => new { 부서코드 = d.부서코드, 부서이름 = d.부서이름, 메모 = d.메모 })
                .ToList();

            // DepartmentList에 데이터 소스 설정
            DepartmentList.DataSource = null;
            DepartmentList.DataSource = selectedDepartments;
        }

        public void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
