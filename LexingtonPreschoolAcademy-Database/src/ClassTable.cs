using LexingtonPreschoolAcademy_Core;

namespace LexingtonPreschoolAcademy_Database;

public class ClassTable : BaseTable 
{
    public required ClassOption Class { get; set; }

    public required int StudentId { get; set; } 

    public StudentTable Student { get; } = null!;
}