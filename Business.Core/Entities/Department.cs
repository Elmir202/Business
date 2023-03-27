using Business.Core.Interfaces;

namespace Business.Core.Entities;

public class Department : IEntity
{
    public int Id { get ; }
    public string DepartmentName { get ; set ; } 
    public int EmployeeLimit { get ; set ; }
    
    public int CompanyId { get ; set ; }
    private static int _counter { get; set ; }

    public Department()
    {
        Id=_counter++;
    }
    public Department(string department_name, int employeeLimit,int company_Id):this() 
    {
        DepartmentName=department_name;
        EmployeeLimit = employeeLimit;
        CompanyId = company_Id;
    }
}
