using Business.Infrustructor.DBcontext;
using Business.Infrustructor.Services;
using Business.Infrustructor.Utilities.Exceptions;
using Business.Infrustructor.Utilities.Helpers;

EmployeeService employeeService = new();
DepartmentService departmentService = new();
CompanyService companyService = new();

Console.WriteLine("Welcome");

while (true)
{
options:
    Console.WriteLine("\n***********************************" +
        "\n0->Exit" +
        "\n1->Create Employee" +
        "\n2->List Employee" +
        "\n3->Create Department" +
        "\n4->List Department" +
        "\n5->Create Company" +
        "\n6->List Company" +
        "\n7->Update Department" +
        "\n8->Get All Departments by Company" +
        "\n9->Get All Employee by Department" +
        "\n***********************************");
    string? result = Console.ReadLine();
    int menu;
    bool TryToInt = int.TryParse(result, out menu);
    if (TryToInt)
    {
        if (menu >= 0 && menu <= 9)
        {
            switch (menu)
            {
                case (int)option.Exit:
                    Environment.Exit(0);
                    break;
                case (int)option.EmployeeCreate:
                    for (int i = 0; i < AppDBcontext.departments.Length; i++)
                    {
                        if (AppDBcontext.departments[i] is null)
                        {
                            Console.WriteLine("Not Found Department:");
                            goto options;
                        }
                        else
                        {
                            break;
                        }
                    }

                select_name:
                    Console.WriteLine("Enter Employee Name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Employee Surname: ");
                    string? sur_name = Console.ReadLine();

                select_salary:
                    Console.WriteLine("Enter Employee Salary: ");
                    string? value = Console.ReadLine();
                    decimal salary;
                    bool TryToValue = decimal.TryParse(value, out salary);
                    if (salary < 0)
                    {
                        Console.WriteLine("Enter Correct Number");
                        goto select_salary;

                    }
                    if (!TryToValue)
                    {
                        Console.WriteLine("Enter Correct Format");
                        goto select_salary;
                    }

                select_department:
                    departmentService.GetAll();
                    Console.WriteLine("Enter Department(Id):");
                    string? department = Console.ReadLine();
                    int department_id;
                    bool TryToIddepartment = int.TryParse(department, out department_id);
                    if (!TryToIddepartment)
                    {
                        Console.WriteLine("Enter Deparment Id:");
                        goto select_department;
                    }
                    try
                    {
                        employeeService.Create(name, sur_name, salary, department_id);
                        Console.WriteLine("Succesfully created");
                    }
                    catch (AddDepartmentFailedException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto select_department;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case option.EmployeeCreate;
                    }
                    break;

                case (int)option.GetListEmployee:
                    for (int i = 0; i < AppDBcontext.employees.Length; i++)
                    {
                        if (AppDBcontext.employees[i] is null)
                        {
                            Console.WriteLine("Not Found Employers:");
                            goto options;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Employee List:");
                    employeeService.GetAll();
                    break;

                case (int)option.DepartmentCreate:
                    for (int i = 0; i < AppDBcontext.companies.Length; i++)
                    {
                        if (AppDBcontext.companies[i] is null)
                        {
                            Console.WriteLine("Not Found Company");
                            goto options;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Enter Department Name: ");
                    string? department_name = Console.ReadLine();

                employee_Limit:
                    Console.WriteLine("Enter Department Employee Limited: ");
                    string? limit_employee = Console.ReadLine();
                    int employee_Limit;
                    bool TryToLimit = int.TryParse(limit_employee, out employee_Limit);
                    if (!TryToLimit || employee_Limit < 0)
                    {
                        Console.WriteLine("Enter corret Format");
                        goto employee_Limit;
                    }

                select_company:
                    companyService.GetAll();
                    Console.WriteLine("Enter Company (Id):");
                    string? select_company = Console.ReadLine();
                    int company_id;
                    bool TryToIdCompany = int.TryParse(select_company, out company_id);
                    if (!TryToIdCompany)
                    {
                        Console.WriteLine("Enter correct Company Id:");
                        goto select_company;
                    }
                    try
                    {
                        departmentService.Create(department_name, employee_Limit, company_id);
                        Console.WriteLine("Succesfully created");
                    }
                    catch (AddDepartmentFailedException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto select_company;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case option.DepartmentCreate;
                    }
                    break;

                case (int)option.GetListDepartment:
                    for (int i = 0; i < AppDBcontext.departments.Length; i++)
                    {
                        if (AppDBcontext.departments[i] is null)
                        {
                            Console.WriteLine("Not Found Departments:");
                            goto options;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Department List:");
                    departmentService.GetAll();
                    break;

                case (int)option.CompanyCreate:
                    Console.WriteLine("Enter Company Name:");
                    try
                    {
                        string? res_companyname = Console.ReadLine();
                        companyService.Create(res_companyname);
                        Console.WriteLine($"New company is created:{res_companyname}");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)option.GetListCompany:
                    for (int i = 0; i < AppDBcontext.companies.Length; i++)
                    {
                        if (AppDBcontext.companies[i] is null)
                        {
                            Console.WriteLine("Not Found Companies:");
                            goto options;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Company List:");
                    companyService.GetAll();
                    break;

                case (int)option.DepartmentUpdate:

                select_update:
                    departmentService.GetAll();
                    Console.WriteLine("Enter Update Id");
                    string? update = Console.ReadLine();
                    int updateId;
                    bool TryToupdateId = int.TryParse(update, out updateId);
                    if (!TryToupdateId)
                    {
                        Console.WriteLine("Enter Correct Format");
                        goto select_update;
                    }
                    if (updateId < 0)
                    {
                        Console.WriteLine("Id cant be below zero");
                        goto select_update;
                    }
                    Console.WriteLine("Enter Department Name");
                    string? newname = Console.ReadLine();

                new_Limit:
                    Console.WriteLine("Enter Limit");
                    string? newLimit = Console.ReadLine();
                    int new_Limit;
                    bool TryToNewLimit = int.TryParse(newLimit, out new_Limit);
                    if (!TryToNewLimit)
                    {
                        Console.WriteLine("Enter Correct");
                        goto new_Limit;
                    }
                    try
                    {
                        departmentService.DepartmentUpdate(updateId, newname, new_Limit);
                        Console.WriteLine("SuccesFully created");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case option.DepartmentUpdate;
                    }
                    break;

                case (int)option.GetDepartmentByCompany:
                    Console.WriteLine("Enter Company Name:");
                    string? selectname = Console.ReadLine();
                    try
                    {
                        companyService.GetAllDepartmentByCompany(selectname);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (NotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)option.GetEmployeesByDepartment:
                    Console.WriteLine("Enter Department Name:");
                    string? selectdpname = Console.ReadLine();
                    try
                    {
                        employeeService.GetAllEmployeeByDepartment(selectdpname);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (NotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }
        else
        {
            Console.WriteLine("Enter Correct Number:");
        }
    }
}