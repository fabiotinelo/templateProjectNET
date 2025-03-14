using Microsoft.EntityFrameworkCore;

namespace Globant.StandardArchitecture.Infrastructure.Persistence
{
    public class BaseDbContext : DbContext
    {
        private readonly DatabaseType databaseType;
        private readonly string connectionString;

        public BaseDbContext(DatabaseType databaseType, string connectionString)
        {
            this.databaseType = databaseType;
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    optionsBuilder.UseSqlServer(connectionString);
                    break;
                case DatabaseType.PostgreSQL:
                    optionsBuilder.UseNpgsql(connectionString);
                    break;
                case DatabaseType.MySQL:
                    optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
                    break;
                case DatabaseType.Oracle:
                    optionsBuilder.UseOracle(connectionString);
                    break;
                default:
                    throw new NotSupportedException("Banco de dados não suportado.");
            }
        }
    }
}
