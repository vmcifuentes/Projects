using System.Data;
using System.Data.SqlClient;

namespace _02_DAO.Model
{
    class Connection
    {
        public SqlConnection connection;
        public SqlCommand sqlCommand; 
        public SqlDataReader sqlDataReader;

        public Connection()
        {
            // Conexión BD Local
            //connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Productos_DB.mdf;Integrated Security=True");

            // Conexión BD Server
            connection = new SqlConnection("Data Source=DESKTOP-VAIKGD8\\SQLEXPRESS;Initial Catalog=Productos_DBSSMS;Integrated Security=true"); 
        }
    }
}
