using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumStudy
{
    public class DepartmentModel
    {
        public string 부서ID { get; set; }
        public string 부서코드 { get; set; }
        public string 부서이름 { get; set; }
        public string 메모 { get; set; }

        public override string ToString()
        {
            return $"부서ID: {부서ID}, 부서코드: {부서코드}, 부서이름: {부서이름}, 메모: {메모}";
        }
    }

}
