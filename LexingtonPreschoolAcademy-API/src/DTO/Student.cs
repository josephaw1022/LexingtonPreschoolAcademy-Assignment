namespace LexingtonPreschoolAcademy_API.DTO.Student;

using System;
using LexingtonPreschoolAcademy_Core;



public class CreateStudentRequestBody
{

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public List<string> Classes { get; set; } = new List<string>();

    internal void Deconstruct(out string FirstName, out string LastName, out List<string> Classes)
    {
        FirstName = this.FirstName;
        LastName = this.LastName;
        Classes = this.Classes;
    }
}


public class CreateStudentResponseBody
{
    public Guid Id { get; set; } = Guid.Empty;


}



public class GetStudentResponseBody
{


}


public class UpdateStudentRequestBody
{
    public Guid Id { get; set; } = Guid.Empty;
}


public class UpdateStudentResponseBody
{

}

