using Ivan_Pegov_KT_31_22.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ivan_Pegov_KT_31_22.Configurations
{
    public class TeacherDisciplineConfiguration : IEntityTypeConfiguration<TeacherDiscipline>
    {
        public void Configure(EntityTypeBuilder<TeacherDiscipline> builder)
        {
            builder.HasKey(td => new { td.TeacherId, td.DisciplineId });

            builder.HasOne(td => td.Teacher)
                .WithMany(t => t.TeacherDisciplines)
                .HasForeignKey(td => td.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(td => td.Discipline)
                .WithMany(d => d.TeacherDisciplines)
                .HasForeignKey(td => td.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
