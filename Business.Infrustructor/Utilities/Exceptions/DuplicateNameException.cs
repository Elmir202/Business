namespace Business.Infrustructor.Utilities.Exceptions;

public class DuplicateNameException:Exception
{
    public DuplicateNameException(string message):base(message) { }
}
