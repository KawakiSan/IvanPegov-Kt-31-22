using Microsoft.EntityFrameworkCore;
using Ivan_Pegov_KT_31_22.Models;
using Ivan_Pegov_KT_31_22.Database.Configurations;
using Ivan_Pegov_KT_31_22.Configurations;

namespace Ivan_Pegov_KT_31_22.DataBase
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<TeacherDiscipline> TeacherDisciplines { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Применяем конфигурации к моделям
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherDisciplineConfiguration());
        }
    }
}