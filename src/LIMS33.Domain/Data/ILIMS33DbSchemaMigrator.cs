using System.Threading.Tasks;

namespace LIMS33.Data
{
    public interface ILIMS33DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
