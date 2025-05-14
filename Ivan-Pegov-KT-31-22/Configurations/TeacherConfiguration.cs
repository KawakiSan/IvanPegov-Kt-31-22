using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivan_Pegov_KT_31_22.Models;

namespace Ivan_Pegov_KT_31_22.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Первичный ключ
            builder.HasKey(t => t.TeacherId);

            // Колонки
            builder.Property(t => t.TeacherId)
                .HasColumnName("teacher_id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(100);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasMaxLength(100);

            builder.Property(t => t.MiddleName)
                .HasColumnName("middle_name")
                .HasMaxLength(100);

            builder.Property(t => t.DepartmentId)
                .HasColumnName("department_id");

            builder.Property(t => t.IsDeleted)
                .HasColumnName("is_deleted");

            // Связь на кафедру
            builder.HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}