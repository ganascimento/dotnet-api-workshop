using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Seeds
{
    public static class ServiceSeed {
        public static void Seed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ServiceEntity>().HasData(
                new ServiceEntity {
                    Id = 1,
                    CreateAt = DateTime.Now,
                    Name = "Alinhamento de rodas",
                    WorkUnits = 1
                },
                new ServiceEntity {
                    Id = 2,
                    CreateAt = DateTime.Now,
                    Name = "Lavação",
                    WorkUnits = 2
                },
                new ServiceEntity {
                    Id = 3,
                    CreateAt = DateTime.Now,
                    Name = "Troca de Óleo",
                    WorkUnits = 3
                },
                new ServiceEntity {
                    Id = 4,
                    CreateAt = DateTime.Now,
                    Name = "Revisão básica",
                    WorkUnits = 5
                },
                new ServiceEntity {
                    Id = 5,
                    CreateAt = DateTime.Now,
                    Name = "Revisão completa",
                    WorkUnits = 8
                }
            );
        }
    }
}