using System;
using System.Data;
using System.Data.SqlClient;

namespace _02_DAO.Model
{
    class DAOImplementation : IProductDAO
    {
        // Objeto conexión
        private Connection conn;

        // Constructor
        public DAOImplementation() 
        {
            conn = new Connection();
        }

        /* CRUD Operations vía DAO */
        // Método para realizar INSERT
        public void CrearProducto(Producto p)
        {
            string insert = "EXEC InsertProducto @codigo='" +
                p.Codigo + "', @descripcion='" + p.Desc +
                "', @precio='" + p.Precio + "', @cantidad='" +
                p.Cantidad + "'";
            DoSQL(insert);
        }

        // Método para realizar operaciones NON-QUERY (Insert, Update y Delete)
        private void DoSQL(string consultaSQL)
        {
            conn.connection.Open();
            conn.sqlCommand = new SqlCommand(consultaSQL, conn.connection);
            conn.sqlCommand.ExecuteNonQuery();
            conn.connection.Close();
        }

        // Método para realizar CONSULTAS
        public Producto ConsultarProducto(string codigo)
        {
            // ExecuteReader() >> SQLDataReader >> sqlDataReader 
            Producto producto = null;
            conn.connection.Open();
            string select = "EXEC ConsultarProducto @codigo='" + codigo + "'";
            conn.sqlCommand = new SqlCommand(select, conn.connection);
            conn.sqlDataReader = conn.sqlCommand.ExecuteReader();
            // While o If dependiendo del caso específico
            if (conn.sqlDataReader.Read())
            {
                producto = new Producto();
                producto.Codigo = conn.sqlDataReader[0].ToString();
                producto.Desc = conn.sqlDataReader[1].ToString();
                producto.Precio = Decimal.Parse(conn.sqlDataReader[2].ToString());
                producto.Cantidad = Int32.Parse(conn.sqlDataReader[3].ToString());
            }
            conn.connection.Close();
            return producto;
        }

        // Método para realizar UPDATE
        public void ActualizarProducto(Producto p) 
        {
            string update = "EXEC ActualizarProducto @codigo='" + p.Codigo +
                "',@descripcion='" + p.Desc + "',@precio='" + p.Precio +
                "',@cantidad='" + p.Cantidad + "'";
            DoSQL(update);
        }

        // Método para realizar DELETE
        public void EliminarProducto(string codigo)
        {
            string delete = "EXEC EliminarProducto @codigo='" + codigo + "'";
            DoSQL(delete);
        }

        // Métodos para consultas personalizadas
        public DataTable makeQuery(string query)
        {
            conn.connection.Open();
            conn.sqlCommand = new SqlCommand(query, conn.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(conn.sqlCommand);
            DataTable table = new DataTable();
            adapter.Fill(table);
            conn.connection.Close();
            return table;
        }

    }
}
