using Business.Core.Entities;
using Business.Infrustructor.DBcontext;
using Business.Infrustructor.Utilities.Exceptions;

namespace Business.Infrustructor.Services;

public class EmployeeService
{
    private static int _count = 0;
    
    public void Create(string name,string surname, decimal salary,int department_id)
    {
        foreach (var department in AppDBcontext.departments)
        {
            if (department is null)
            {
                throw new NotFoundException("Not Found Department id:");
            }
            if (department.Id == department_id) break;

        }
        if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname)) 
        {
            throw new ArgumentNullException();    
        }
        
            Employee employee = new(name,surname,salary,department_id);
            AppDBcontext.employees[_count++] = employee;

    }
    public void GetAll()
    {
        for(int i=0;i<_count;i++) 
        {
            Console.WriteLine("\n**********************************************************\n");
            Console.WriteLine($"Employee Id: {AppDBcontext.employees[i].Id} " +
                $"Employee Name: {AppDBcontext.employees[i].Name} " +
                $"Employee Surname: {AppDBcontext.employees[i].Surname} " +
                $"Employee Salary: {AppDBcontext.employees[i].Salary} ");
            Console.WriteLine("\n**********************************************************\n");


        }
    }

    public void GetAllEmployeeByDepartment(string selectdpname)
    {
        bool departmentemployee= false;
        foreach(var department in AppDBcontext.departments)    
        {
            if (department.DepartmentName.ToUpper()==selectdpname.ToUpper())
            {
                Console.WriteLine("Employers: ");
                foreach (var employee in AppDBcontext.employees)
                {
                    if (employee!= null && employee.DepartmentId == department.Id) 
                    { Console.WriteLine(employee.Name); }
                }
                departmentemployee= true;
                break;
            }
        }
        if(!departmentemployee)
        {
            throw new NotExistException("There are no employee the department list");
        }
    }

    public void EmployeeUpdate(int employe_update, string name, string surname,decimal salary)
    {

        for (int i = 0; i < AppDBcontext.employees.Length; i++)
        {
            if (AppDBcontext.employees[i].Id == employe_update)
            {
                AppDBcontext.employees[employe_update].Name = name;
                AppDBcontext.employees[employe_update].Surname = surname;
                AppDBcontext.employees[employe_update].Salary = salary;
                break;
            }
        }
    }
}
