using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;


namespace my_agenda
{
    class Agenda
    {
        private SQLiteConnection cn = null;
        private SQLiteCommand cmd = null;
        private SQLiteDataReader reader = null;
        private DataTable table = null;


        public bool insertar(string nombre, string telefono)
        {
            try
            {
                string query = "INSERT INTO Directorio(nombre,telefono) VALUES ('" + nombre + "', '" + telefono + "' )";
                cn = Conexion.conectar();
                cn.Open();
                cmd = new SQLiteCommand(query, cn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }

            }

            return false;

        }

        public DataTable consultar()
        {
            try
            {
                nombreColumnas();
                string query = "SELECT * FROM Directorio";
                cn = Conexion.conectar();
                cn.Open();
                cmd = new SQLiteCommand(query, cn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    table.Rows.Add(new object[] { reader["id"], reader["nombre"], reader["telefono"] });

                }
                reader.Close();
                cn.Close();
                return table;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }

            }

            return table;

        }

        public bool eliminar(int id)
        {
            try
            {
                string query = "DELETE FROM Directorio WHERE id = '" + id + "' ";
                cn = Conexion.conectar();
                cn.Open();
                cmd = new SQLiteCommand(query, cn);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    cn.Close();
                    return true;

                }
            }

            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Ha ocurrido un error en el proceso");

            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }

            }
            return false;
       }


        public bool actualizar(int id, string nombre, string telefono)
        {
            try
            {
                string query = "UPDATE Directorio SET nombre='" + nombre + "',telefono= '" + telefono + "' WHERE id= '" + id.ToString() + "' ";
                cn = Conexion.conectar();
                cn.Open();
                cmd = new SQLiteCommand(query, cn);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    cn.Close();
                    return true;

                }
            }

            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Ha ocurrido un error en el proceso");

            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }

            }
            return false;


        }

        private void nombreColumnas()
        {
            table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Nombre");
            table.Columns.Add("Telefono");
        }

    }

   
}
