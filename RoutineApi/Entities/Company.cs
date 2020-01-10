using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineApi.Entities
{
    public class Company
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 公司下的员工集合
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
    }
}
