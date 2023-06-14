using Microsoft.AspNetCore.Mvc;
using LexingtonPreschoolAcademy_API.DTO;
using LexingtonPreschoolAcademy_API.DTO.Student;
using LexingtonPreschoolAcademy_Database;
using LexingtonPreschoolAcademy_Core;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace LexingtonPreschoolAcademy_API.Controllers;

//! The business logic shouldnt be in the controller, but its fine for now
[ApiController]
[Route("student")]
public class StudentController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly LexingtonPreschoolAcademyDatabaseContext _dbContext;
    private readonly ILogger<StudentController> _logger;

    public StudentController(
        IConfiguration configuration,
        LexingtonPreschoolAcademyDatabaseContext dbContext,
        ILogger<StudentController> logger
    )
    {
        _configuration = configuration;
        _dbContext = dbContext;
        _logger = logger;
    }


    /// <summary>
    /// Get all students
    /// </summary>
    /// <returns>
    /// The list of students
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetMany()
    {
        var listOfStudents = await _dbContext.Students
            .Include(s => s.Classes)
            .ToArrayAsync();


        var response = new ListResponse<StudentTable>
        {
            Dataset = listOfStudents,
            Total = listOfStudents.Length,
        };


        return Ok(response);
    }


    /// <summary>
    /// Create a student 
    /// </summary>
    /// <param name="requestBody">
    /// The student to create
    /// </param>
    /// <returns>
    /// The created student
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> CreateStudent(
        [FromBody] CreateStudentRequestBody requestBody
    )
    {

        var (FirstName, LastName, Classes) = requestBody;

        var student = new StudentTable
        {
            FirstName = FirstName,
            LastName = LastName,
        };

        _logger.LogDebug("Creating student {@student}", student);


        var addStudentResponse = await _dbContext.Students.AddAsync(student);


        List<ClassTable> classTables = new();

        foreach (var studentClass in Classes)
        {

            var temporaryTable = new ClassTable() { Class = ClassOption.Math };
            var validClass = false;

            switch (studentClass)
            {
                case "Math":
                    temporaryTable = new ClassTable { Class = ClassOption.Math, Student = addStudentResponse.Entity, StudentId = addStudentResponse.Entity.Id };
                    validClass = true;
                    break;
                case "Science":
                    temporaryTable = new ClassTable { Class = ClassOption.Science,Student = addStudentResponse.Entity, StudentId = addStudentResponse.Entity.Id };
                    validClass = true;
                    break;
                case "History":
                    temporaryTable = new ClassTable { Class = ClassOption.History,Student = addStudentResponse.Entity, StudentId = addStudentResponse.Entity.Id };
                    validClass = true;
                    break;
                case "Spanish":
                    temporaryTable = new ClassTable { Class = ClassOption.Spanish,Student = addStudentResponse.Entity, StudentId = addStudentResponse.Entity.Id };
                    validClass = true;
                    break;
                case "P.E.":
                    temporaryTable = new ClassTable { Class = ClassOption.P_E,Student = addStudentResponse.Entity, StudentId = addStudentResponse.Entity.Id };
                    validClass = true;
                    break;
                case "Art":
                    temporaryTable = new ClassTable { Class = ClassOption.Art,Student = addStudentResponse.Entity, StudentId = addStudentResponse.Entity.Id };
                    validClass = true;
                    break;
                default:
                    break;
            }

            if (validClass)
            {
                _logger.LogDebug("Creating class {@class}", temporaryTable);
                await _dbContext.Classes.AddAsync(temporaryTable);
                await _dbContext.SaveChangesAsync();
            }
        }



        return CreatedAtAction(
            nameof(CreateStudent),
            new { id = addStudentResponse.Entity.Id },
           addStudentResponse.Entity
        );
    }


}



