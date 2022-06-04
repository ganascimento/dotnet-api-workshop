using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class WorkshopMapping : IEntityTypeConfiguration<WorkshopEntity>
    {
        public void Configure(EntityTypeBuilder<WorkshopEntity> builder)
        {
            builder.ToTable("Workshop");

            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Auth);
        }
    }
}