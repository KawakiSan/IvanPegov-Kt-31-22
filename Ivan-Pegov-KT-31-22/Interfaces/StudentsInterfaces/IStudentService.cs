using Ivan_Pegov_KT_31_22.DataBase;
using Ivan_Pegov_KT_31_22.Filters.StudentFilters;
using Ivan_Pegov_KT_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivan_Pegov_KT_31_22.Interfaces.StudentInterfaces
{

    public interface IStudentService
    {
        Task<Teacher[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Teacher[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            return _dbContext.Teachers
                .Include(t => t.Department)
                .Where(t => !t.IsDeleted && t.Department.Name == filter.GroupName)
                .ToArrayAsync(cancellationToken);
        }
    }
    public interface IDisciplineService
    {
        Task<Discipline[]> GetDisciplinesFilteredAsync(DisciplineFilter filter, CancellationToken cancellationToken = default);
    }


    public class DisciplineService : IDisciplineService
    {
        private readonly StudentDbContext _dbContext;

        public DisciplineService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Discipline[]> GetDisciplinesFilteredAsync(DisciplineFilter filter, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Disciplines
                .Include(d => d.TeacherDisciplines)
                .ThenInclude(td => td.Teacher)
                .Where(d => !d.IsDeleted)
                .AsQueryable();

            if (filter.MinLoadHours.HasValue)
                query = query.Where(d => d.LoadHours >= filter.MinLoadHours.Value);

            if (filter.MaxLoadHours.HasValue)
                query = query.Where(d => d.LoadHours <= filter.MaxLoadHours.Value);

            if (filter.TeacherId.HasValue)
                query = query.Where(d => d.TeacherDisciplines.Any(td => td.TeacherId == filter.TeacherId.Value));

            return await query.ToArrayAsync(cancellationToken);
        }
    }
}