using Business.Core.Interfaces;

namespace Business.Core.Entities;

public class Company : IEntity
{
    public int Id { get ; }
    public string Name { get ; set ; }
    private static int _counter { get; set ; }
    public Company()
    {
        Id=_counter++;
    }

    public Company( string name):this() 
    {
        Name = name;
    }
}
