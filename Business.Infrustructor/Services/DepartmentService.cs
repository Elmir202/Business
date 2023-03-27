using Business.Core.Entities;
using Business.Infrustructor.DBcontext;
using Business.Infrustructor.Utilities.Exceptions;
using System.Runtime.CompilerServices;

namespace Business.Infrustructor.Services;

public class DepartmentService
{
    private static int _count = 0;
    public void Create(string? name,int employee_Limit,int company_Id)
    {
        foreach (var company in AppDBcontext.companies)
        {
            if (company is null)
            {
                throw new NotFoundException("Not Found Company id");
            }
            if (company.Id == company_Id) break;
        }
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new NotAddException("This Employee is not add");
        }
        bool isExist=false;
        for(int i = 0; i < _count; i++)
        {
            if (AppDBcontext.departments[i].DepartmentName.ToUpper() == name.ToUpper()) 
            {
                isExist= true; 
                break;
            }
        }
        if(isExist) 
        {
            throw new DuplicateNameException("This department name already exist");
        }
        Department new_department =new Department(name,employee_Limit,company_Id);
        AppDBcontext.departments[_count++]= new_department;
    }
    public void GetAll()
    {
        for(int i = 0;i< _count; i++)
        {
            string temp_company=string.Empty;
            foreach (var company in AppDBcontext.companies)
            {
                if (company == null) break;
                if (AppDBcontext.departments[i].CompanyId==company.Id)
                {
                    temp_company = company.Name; break; 
                }
            }

            Console.WriteLine("\n**********************************************************\n");
            Console.WriteLine($"Department Id: {AppDBcontext.departments[i].Id}" +
                $"\nDepartment Name: {AppDBcontext.departments[i].DepartmentName}" +
                $"\nDepartment Employee Limit: {AppDBcontext.departments[i].EmployeeLimit}" +
                $"\nBelongs to:{temp_company}");
            Console.WriteLine("\n**********************************************************\n");

        }
    }
    public void DepartmentUpdate(int update,string name, int limit)
    {
        
        for(int i=0;i<AppDBcontext.departments.Length;i++) 
        {
            if (AppDBcontext.departments[i].Id == update)
            {
                AppDBcontext.departments[update].DepartmentName = name;
                AppDBcontext.departments[update].EmployeeLimit = limit;
                break;
            }
        }
    }
}
