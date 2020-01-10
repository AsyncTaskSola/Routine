using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoutineApi.DbContexts;
using RoutineApi.Entities;

namespace RoutineApi.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RoutineDbContext _context;

        public CompanyRepository(RoutineDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// 公司某ID下的所有员工
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            return await _context.Employees.Where(x => x.CompanyId == companyId).OrderBy(x => x.EmployeeNo)
                .ToArrayAsync();
        }

        /// <summary>
        /// 某员工的id和他所在的部门
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            return await _context.Employees.Where(x => x.CompanyId == companyId && x.Id == employeeId)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// 新增指定公司id下的员工
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="employee"></param>
        public void AddEmployee(Guid companyId, Employee employee)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            employee.CompanyId = companyId;
            _context.Employees.Add(employee);
        }
        /// <summary>
        /// 更新，编辑
        /// </summary>
        /// <param name="employee"></param>

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Update(employee);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employee"></param>
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
        /// <summary>
        /// 全部公司列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }
        /// <summary>
        /// 根据公司id找到公司
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
        }
        /// <summary>
        /// 根据公司名找到该公司id
        /// </summary>
        /// <param name="companyIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds)
        {
            if (companyIds == null)
            {
                throw new ArgumentNullException(nameof(companyIds));
            }

            return await _context.Companies.Where(x => companyIds.Contains(x.Id)).OrderBy(a => a.Name).ToListAsync();
        }
        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="company"></param>
        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
        }
        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="company"></param>
        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
        }
        /// <summary>
        ///退出
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            return await _context.Companies.AnyAsync(x => x.Id == companyId);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
