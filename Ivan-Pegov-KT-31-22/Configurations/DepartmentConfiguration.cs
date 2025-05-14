using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivan_Pegov_KT_31_22.Models;

namespace Ivan_Pegov_KT_31_22.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Первичный ключ
            builder.HasKey(d => d.DepartmentId);

            // Колонки
            builder.Property(d => d.DepartmentId)
                .HasColumnName("department_id")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(200);

            builder.Property(d => d.FoundationDate)
                .HasColumnName("foundation_date");

            builder.Property(d => d.HeadId)
                .HasColumnName("head_id");

            builder.Property(d => d.IsDeleted)
                .HasColumnName("is_deleted");

            // Связь на заведующего кафедрой
            builder.HasOne(d => d.Head)
                .WithMany() // У заведующего нет списка кафедр
                .HasForeignKey(d => d.HeadId)
                .OnDelete(DeleteBehavior.Restrict); // При удалении заведующего кафедра не должна удаляться
        }
    }
}