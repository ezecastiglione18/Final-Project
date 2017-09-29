using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Drawing;

namespace MonoGame
{
    class ConexionBDSports
    {
        public OleDbConnection conexion;
        public OleDbCommand consulta;
        public List<Sports> ListaSports = new List<Sports>();
        Random random = new Random();
        public int[] randomNums = new int[8];
        public void abrirConexion()
        {
            conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|Difficult.mdb");
            conexion.Open();
            consulta = conexion.CreateCommand();
        }

        public List<Sports> Seleccionar()
        {
            abrirConexion();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "Random8";
            selecRandom();
            consulta.Parameters.Add(new OleDbParameter("id1", randomNums[0]));
            consulta.Parameters.Add(new OleDbParameter("id2", randomNums[1]));
            consulta.Parameters.Add(new OleDbParameter("id4", randomNums[2]));
            consulta.Parameters.Add(new OleDbParameter("id3", randomNums[3]));
            consulta.Parameters.Add(new OleDbParameter("id5", randomNums[4]));
            consulta.Parameters.Add(new OleDbParameter("id6", randomNums[5]));
            consulta.Parameters.Add(new OleDbParameter("id7", randomNums[6]));
            consulta.Parameters.Add(new OleDbParameter("id8", randomNums[7]));

            OleDbDataReader drConsulta = consulta.ExecuteReader();
            while (drConsulta.Read())
            {
                Sports oSports = new Sports();
                oSports.Nombre = drConsulta["Texto"].ToString();
                oSports.Ruta = drConsulta["Ruta"].ToString();
                oSports.Id = Convert.ToInt32(drConsulta["Identificador"]);

                ListaSports.Add(oSports);
            }
            conexion.Close();
            return ListaSports;
        }

        private int[] selecRandom()
        {
            int rnd;
            for (int i = 0; i < 8; i++)
            {
                rnd = random.Next(1, 15);
                while (randomNums.Contains(rnd))
                {
                    rnd = random.Next(1, 15);
                }
                randomNums[i] = rnd;
            }
            return randomNums;
        }
    }
}
