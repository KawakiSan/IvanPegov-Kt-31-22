using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivan_Pegov_KT_31_22.Models;

namespace Ivan_Pegov_KT_31_22.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasKey(d => d.DisciplineId);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.LoadHours)
                .IsRequired();

            builder.Property(d => d.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
