using Business.Core.Entities;

namespace Business.Infrustructor.DBcontext;

public class AppDBcontext
{
    public static Employee[] employees { get; set; } = new Employee[100];
    public static Department[] departments { get; set; } = new Department[100];
    public static Company[] companies { get; set; } = new Company[100];

}
