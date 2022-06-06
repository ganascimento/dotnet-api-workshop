using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Server=127.0.0.1;Port=3306;DataBase=workshop;Uid=root;Pwd=mysql";

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(5, 7))
            );

            return new DataContext(optionsBuilder.Options);
        }
    }
}