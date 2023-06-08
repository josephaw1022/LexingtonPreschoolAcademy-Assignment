using LexingtonPreschoolAcademy_Core;

namespace LexingtonPreschoolAcademy_Database;

public class ClassTable : BaseTable, IClass
{
    public required ClassOption Class { get; set; }
    public List<StudentTable> Students { get; } = new();
}