using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class AuthMapping : IEntityTypeConfiguration<AuthEntity>
    {

        public void Configure(EntityTypeBuilder<AuthEntity> builder)
        {
            builder.ToTable("Auth");

            builder.HasKey(u => u.Id);
        }
    }
}