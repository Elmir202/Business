using Business.Core.Interfaces;

namespace Business.Core.Entities;

public class Employee : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; } 
    private static int _counter { get; set; }
    public Employee()
    {
        Id=_counter++;
    }

    public Employee(string name, string surname, decimal salary,int department_id):this() 
    {
        Name = name;
        Surname = surname;
        Salary = salary;
        DepartmentId = department_id;
    }
    public override string ToString()
    {
        return ($"Employee{{name={Name},surname={Surname}}}");
    }
}
