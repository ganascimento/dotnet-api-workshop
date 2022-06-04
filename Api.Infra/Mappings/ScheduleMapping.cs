using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class ScheduleMapping : IEntityTypeConfiguration<ScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
        {
            builder.ToTable("Schedule");

            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Service);

            builder.HasOne(u => u.Workshop)
                .WithMany(m => m.Schedules);
        }
    }
}