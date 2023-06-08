namespace LexingtonPreschoolAcademy_API.DTO.Student;

using System;
using LexingtonPreschoolAcademy_Core;



public class CreateStudentRequestBody
{

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public ClassOption[] Classes { get; set; } = Array.Empty<ClassOption>();
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

