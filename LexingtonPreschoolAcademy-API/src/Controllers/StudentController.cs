using Microsoft.AspNetCore.Mvc;
using LexingtonPreschoolAcademy_Core;
using LexingtonPreschoolAcademy_API.DTO.Student;
using LexingtonPreschoolAcademy_Database;


namespace LexingtonPreschoolAcademy_API.Controllers;


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
    public IActionResult GetMany()
    {
        var listOfStudents = _dbContext.Students.ToList().ToArray();

        return Ok(listOfStudents);
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
    public IActionResult Create(
        [FromBody] CreateStudentRequestBody requestBody
    )
    {

        return Ok();
    }
}



