using Business.Core.Entities;
using Business.Infrustructor.DBcontext;
using Business.Infrustructor.Utilities.Exceptions;

namespace Business.Infrustructor.Services;

public class CompanyService
{
    private static int _count = 0;
    public void Create(string? name)
    {
        if(String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool IsExist=false;
        for(int i=0;i<_count;i++)
        {
            if (AppDBcontext.companies[i].Name.ToUpper() == name.ToUpper()) 
            {
                IsExist = true;
                break;
            }
        }
        if(IsExist) 
        {
            throw new DuplicateNameException("This company name already exist");
        }
        Company new_company = new (name);
        AppDBcontext.companies[_count++]=new_company;
    }
    public void GetAll()
    {
        for(int i=0;i<_count;++i) 
        {
            Console.WriteLine($"Id: {AppDBcontext.companies[i].Id}-> Name: {AppDBcontext.companies[i].Name}");                                          
        }
    }
    public void GetAllDepartmentByCompany(string selectname)
    {
        bool companydepartment=false;
        foreach(var company in AppDBcontext.companies)
        {
            if (company.Name.ToUpper()==selectname.ToUpper()) 
            {
                Console.WriteLine("Departments: ");
                foreach (var department in AppDBcontext.departments)
                {
                    
                    if (department!=null && department.CompanyId==company.Id) 
                    { Console.WriteLine(department.DepartmentName); }
                }
                companydepartment= true;
                break;
            }
        }
        if(!companydepartment)
        {
            throw new NotExistException("There are no departments the company list");
        }
    }
}
