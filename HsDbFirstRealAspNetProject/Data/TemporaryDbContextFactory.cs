using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Data
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<HsDbContext>
    {
        public HsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<HsDbContext>();

            var connectionString = configuration.GetConnectionString("HsDbFirstRealAspNetProjectContext");
            builder.UseSqlServer(connectionString);

            // Stop client query evaluation
            builder.ConfigureWarnings(w =>
                w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new HsDbContext(builder.Options);
        }
    }
}
