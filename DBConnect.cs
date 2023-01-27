using System;
using MySqlConnector;

namespace WalkinAPI

{
    public class DBConnect : IDisposable
    {
        public MySqlConnection Connection { get; }
        private IConfiguration Configuration;

        public DBConnect(IConfiguration _configuration)
        {
            Configuration = _configuration;
            var connString = this.Configuration.GetConnectionString("DefaultConnection");
            Connection = new MySqlConnection(connString);
        }

        public void Dispose() => Connection.Dispose();
    }
}