using Ivan_Pegov_KT_31_22.Filters.StudentFilters;
using Ivan_Pegov_KT_31_22.Interfaces.StudentInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ivan_Pegov_KT_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(
            [FromBody] StudentGroupFilter filter,
            CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);
            return Ok(students);
        }
    }
}