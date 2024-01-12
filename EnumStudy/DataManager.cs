using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumStudy
{
    public class DataManager
    {
        private DepartmentModel selectedDepartment;
        private EmployeeModel selectedEmployee;

        private static DataManager instance;

        private DataManager()
        {
            // 생성자를 private로 만들어 외부에서 직접 인스턴스를 생성하지 못하도록 함
        }

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }

        public List<DepartmentModel> Departments { get; set; } = new List<DepartmentModel>();

        public DepartmentModel SelectedDepartment
        {
            get { return selectedDepartment; }
            set { selectedDepartment = value; }
        }
        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
        public EmployeeModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; }
        }
    }
}
