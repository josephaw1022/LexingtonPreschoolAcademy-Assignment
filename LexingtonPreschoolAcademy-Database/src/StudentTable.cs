using LexingtonPreschoolAcademy_Core;

namespace LexingtonPreschoolAcademy_Database;


public class StudentTable : BaseTable 
{
    public required string FirstName { get; set; } = null!;

    public required string LastName { get; set; } = null!;

    public List<ClassTable> Classes { get; set; } = new();
}
