using Ivan_Pegov_KT_31_22.Filters.StudentFilters;
using Ivan_Pegov_KT_31_22.Interfaces.StudentInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ivan_Pegov_KT_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IStudentService _studentService;

        public TeacherController(ILogger<TeacherController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "GetTeachersByGroup")]
        public async Task<IActionResult> GetTeachersByGroupAsync(
            [FromBody] StudentGroupFilter filter,
            CancellationToken cancellationToken = default)
        {
            var teachers = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            // Преобразуем список для удобного вывода
            var result = teachers.Select(t => new
            {
                FullName = $"{t.LastName} {t.FirstName} {t.MiddleName}",
                DepartmentId = t.DepartmentId,
                IsDeleted = t.IsDeleted ? "Да" : "Нет"
            });

            return Ok(result);
        }
    }
}