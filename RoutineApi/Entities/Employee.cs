using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineApi.Entities
{
    public class Employee
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid CompanyId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTimeOffset DateofBirth { get; set; }
        public Company Company { get; set; }
    }

    public enum Gender
    {
        男 = 1,
        女 = 2
    }
}
