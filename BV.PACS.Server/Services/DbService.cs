using System.Data.SqlClient;

namespace BV.PACS.Server.Services
{
    public class DbService
    {
        protected readonly SqlConnectionStringBuilder _builder;

        public DbService()
        {
            // todo: move to config
            _builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-A0AN5I9\\PACS",
                UserID = "sa",
                Password = "btrp!2010",
                InitialCatalog = "PACS_PrachiBMORU_200K"
            };
        }
    }
}