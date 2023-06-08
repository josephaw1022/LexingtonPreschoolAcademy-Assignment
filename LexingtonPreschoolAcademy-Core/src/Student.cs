namespace LexingtonPreschoolAcademy_Core;

public interface IStudent<T> where T : IClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<T> Classes { get;  }
}
