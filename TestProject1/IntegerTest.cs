using Microsoft.EntityFrameworkCore;
using Ivan_Pegov_KT_31_22.Database;
using Ivan_Pegov_KT_31_22.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ivan_Pegov_KT_31_22.DataBase;

namespace Ivan_Pegov_KT_31_22.Tests
{
    public class TeacherSurnameValidationTests : IDisposable
    {
        private readonly DbContextOptions<StudentDbContext> _dbContextOptions;
        private readonly StudentDbContext _context;

        public TeacherSurnameValidationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "teacher_surname_validation_db")
                .Options;
            _context = new StudentDbContext(_dbContextOptions);
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task Teachers_Without_Digits_Are_Valid()
        {
            var teachers = new List<Teacher>
            {
                new Teacher { FirstName = "Ivan", LastName = "Petrov", MiddleName = "Ivanovich" },
                new Teacher { FirstName = "Sergey", LastName = "Ivanov", MiddleName = "Sergeevich" }
            };

            await _context.Set<Teacher>().AddRangeAsync(teachers);
            await _context.SaveChangesAsync();

            var allTeachers = await _context.Set<Teacher>().ToListAsync();

            // Проверка: все фамилии не содержат цифр
            var regexDigits = new Regex(@"\d");
            var invalidTeachers = allTeachers.Where(t => regexDigits.IsMatch(t.LastName)).ToList();

            Assert.Empty(invalidTeachers);
        }

        [Fact]
        public async Task Teachers_With_Digits_Are_Detected()
        {
            var teachers = new List<Teacher>
            {
                new Teacher { FirstName = "Alex", LastName = "Sidorov123", MiddleName = "Alexeevich" }
            };

            await _context.Set<Teacher>().AddRangeAsync(teachers);
            await _context.SaveChangesAsync();

            var allTeachers = await _context.Set<Teacher>().ToListAsync();

            // Проверка на наличие цифр
            var regexDigits = new Regex(@"\d");
            var teachersWithDigits = allTeachers.Where(t => regexDigits.IsMatch(t.LastName)).ToList();

            Assert.Single(teachersWithDigits);
            Assert.Equal("Sidorov123", teachersWithDigits.First().LastName);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}