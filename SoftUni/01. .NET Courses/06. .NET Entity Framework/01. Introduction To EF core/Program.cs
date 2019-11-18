using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using EFCORE.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using EFCORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EFCORE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveTown(new SoftUniContext()));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var result = context.Employees
                    .Select(x => new
                    {
                        Name = x.FirstName,
                        Salary = x.Salary
                    })
                    .Where(x => x.Salary > 50000)
                    .OrderBy(x => x.Name)
                    .ToList();

                foreach (var VARIABLE in result)
                {
                    sb.AppendLine($"{VARIABLE.Name} - {VARIABLE.Salary:F2}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var result = context.Employees
                    .Where(x => x.Department.Name == "Research and Development")
                    .Select(x => new
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Salary = x.Salary
                    }).OrderBy(x => x.Salary).ThenBy(x => x.FirstName).ToList();

                
                foreach (var item in result)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName} Research and Development - ${item.Salary:F2}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

                var address = new Addresses
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };
                nakov.Address = address;

                context.SaveChanges();

                var employees = context.Employees
                    .OrderByDescending(x => x.AddressId)
                    .Take(10)
                    .Select(x => x.Address.AddressText)
                    .ToList();

                foreach (var item in employees)
                {
                    sb.AppendLine(item);
                }

                
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var employees = context.Employees
                    .Where(x => x.EmployeesProjects
                        .Any(z => z.Project.StartDate.Year >= 2001 && z.Project.StartDate.Year <= 2003))
                    .Select(x => new
                    {
                        fistName = x.FirstName,
                        lastName = x.LastName,
                        managerFirstName = x.Manager.FirstName,
                        managerLastName = x.Manager.LastName,
                        projects = x.EmployeesProjects
                            .Select(z => new
                            {
                                startDate = z.Project.StartDate,
                                endDate = z.Project.EndDate,
                                name = z.Project.Name
                            })
                    }).ToList();

                foreach (var item in employees)
                {
                    sb.AppendLine(
                        $"{item.fistName} {item.lastName} - Manager: {item.managerFirstName} {item.managerLastName}");
                    foreach (var project in item.projects)
                    {
                        var startDate =
                            project.startDate.ToString("M/d/yyyy h: mm:ss tt", CultureInfo.InvariantCulture);
                        var endDate = project.endDate == null
                            ? "not finished"
                            : project.endDate.Value.ToString("M/d/ yyyy h: mm:ss tt", CultureInfo.InvariantCulture);
                        sb.AppendLine($"--{project.name} - {startDate} - {endDate}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var addresses = context.Addresses
                    .Select(x => new
                {
                    Text = x.AddressText,
                    Town = x.Town.Name,
                    Employees = x.Employees.Count()
                })
                    .OrderByDescending(x => x.Employees)
                    .ThenBy(x => x.Town)
                    .ThenBy(x => x.Text)
                    .ToList();

                foreach (var address in addresses)
                {
                    sb.AppendLine($"{address.Text}, {address.Town} - {address.Employees} employees");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var watch = Stopwatch.StartNew();
                var employee = context.Employees.Select(x => new
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Projects = x.EmployeesProjects.Select(z => new
                    {
                        Project = z.Project
                    })
                }).FirstOrDefault(x => x.EmployeeId == 147);

                Console.WriteLine(watch.Elapsed);
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                foreach (var project in employee.Projects.OrderBy(x => x.Project.Name))
                {
                    sb.AppendLine(project.Project.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var departments = context.Departments
                    .Where(x => x.Employees.Count > 5)
                    .OrderBy(x => x.Employees.Count)
                    .ThenBy(x => x.Name)
                    .Select(x => new
                    {
                        DepartmentName = x.Name,
                        ManagerFirstName = x.Manager.FirstName,
                        ManagerLastName = x.Manager.LastName,
                        Employees = x.Employees.Select(z => new
                        {
                            EmployeeFirstName = z.FirstName,
                            EmployeeLastName = z.LastName,
                            EmployeeJobTitle = z.JobTitle
                        }).OrderBy(y => y.EmployeeFirstName).ThenBy(c => c.EmployeeLastName)
                    }).ToList();

                foreach (var department in departments)
                {
                    sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");
                    foreach (var employee in department.Employees)
                    {
                        sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var result = context.Projects
                    .Where(x => x.EndDate.HasValue == false)
                    .OrderByDescending(x => x.StartDate)
                    .Take(10)
                    .OrderBy(x => x.Name)
                    .Select(x => new
                    {
                        Name = x.Name,
                        Description = x.Description,
                        StartDate = x.StartDate
                    })
                    .ToList();

                foreach (var project in result)
                {
                    sb.AppendLine(project.Name);
                    sb.AppendLine(project.Description);
                    sb.AppendLine(project.StartDate.ToString("M/d/yyyy h: mm:ss tt", CultureInfo.InvariantCulture));
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();
            string[] departmentsToSearchFor = new[] {"Engineering", "Tool Design", "Marketing"};
            using (context)
            {
                //this is the variant where it updates the Database too
                var results = context.Employees
                    .Where(x => departmentsToSearchFor.Contains(x.Department.Name));
                foreach (var employee in results)
                {
                    employee.Salary = employee.Salary * 12 / 100 + employee.Salary;
                }
                context.SaveChanges();

                foreach (var item in results.ToList())
                {
                    sb.AppendLine(item.FirstName + item.LastName + item.Salary);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var result = context.Employees
                    .Select(x => new
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        JobTitle = x.JobTitle,
                        Salary = x.Salary
                    })
                    .Where(x => x.FirstName.StartsWith("Sa"))
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList();
                foreach (var item in result)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:F2})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var projectToRemove = context.Projects.FirstOrDefault(x => x.ProjectId == 2);
                var projectEmployee = context.EmployeesProjects.FirstOrDefault(x => x.ProjectId == 2);

                
                context.EmployeesProjects.Remove(projectEmployee);
                context.Projects.Remove(projectToRemove);
                context.SaveChanges();

                var projects = context.Projects
                    .Select(x => new
                    {
                        Name = x.Name
                    })
                    .Take(10)
                    .ToList();

                foreach (var project in projects)
                {
                    sb.AppendLine(project.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            using (context)
            {
                var employees = context.Employees.Where(x => x.Address.Town.Name == "Snohomish");
                foreach (var employee in employees)
                {
                    employee.AddressId = null;
                }
                var town = context.Towns.FirstOrDefault(x => x.Name == "Snohomish");
                var adresses = context.Addresses.Where(x => x.Town.Name == "Snohomish");

                int count = adresses.Count();

                context.Addresses.RemoveRange(adresses);
                context.Remove(town);

                context.SaveChanges();

                sb.AppendLine($"{count} addresses in Kent were deleted");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
