using Ivan_Pegov_KT_31_22.Filters.StudentFilters;
using Ivan_Pegov_KT_31_22.Interfaces.StudentInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ivan_Pegov_KT_31_22.Controllers
{
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetDisciplinesFilteredAsync([FromBody] DisciplineFilter filter, CancellationToken cancellationToken)
        {
            var disciplines = await _disciplineService.GetDisciplinesFilteredAsync(filter, cancellationToken);
            return Ok(disciplines);
        }
    }
}
