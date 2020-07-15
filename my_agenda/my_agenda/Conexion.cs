using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace my_agenda
{
    class Conexion
    {

        public static SQLiteConnection conectar()
        {
            string database = Application.StartupPath + "\\AgendaBD.db";
            SQLiteConnection cn = new SQLiteConnection("Data Source =" + database);
            //SQLiteConnection cn = new SQLiteConnection("Data Source = C:\\Users\\Yodelvi\\Desktop\\Agenda C#\\AgendaBD.db");
            return cn;

        }


    }
}
