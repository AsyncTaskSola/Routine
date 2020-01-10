using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoutineApi.Entities;

namespace RoutineApi.Services
{
    /// <summary>
    /// Company资料库的接口
    /// </summary>
    public interface ICompanyRepository
    {
        /// <summary>
        /// 公司某ID下的所有员工
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId);

        /// <summary>
        /// 员工的ID 和所在公司的ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId);

        void AddEmployee(Guid companyId, Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

        /// <summary>
        /// 公司列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Company>> GetCompaniesAsync();

        /// <summary>
        /// 根据companyId指定的公司
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<Company> GetCompanyAsync(Guid companyId);

        /// <summary>
        /// companyIds指定公司下的公司信息
        /// </summary>
        /// <param name="companyIds"></param>
        /// <returns></returns>
        Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid>companyIds);

        void AddCompany(Company company);

        void DeleteCompany(Company company);

        void UpdateCompany(Company company);
        Task<bool> CompanyExistsAsync(Guid companyId);
        Task<bool> SaveAsync();

    }
}
