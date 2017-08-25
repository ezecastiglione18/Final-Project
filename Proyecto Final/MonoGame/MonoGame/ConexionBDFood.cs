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
    class ConexionBDFood
    {
        public OleDbConnection conexion;
        public OleDbCommand consulta;
        public List<Food> ListaFood = new List<Food>();
        Random random = new Random();
        public int[] randomNums = new int[] { 7, 7, 7, 7, 7, 7 };

        public void abrirConexion()
        {
            conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|Food.mdb");
            conexion.Open();
            consulta = conexion.CreateCommand();
        }

        public List<Food> Seleccionar()
        {
            abrirConexion();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "Random 8";
            selecRandom();
            consulta.Parameters.Add(new OleDbParameter("id1", randomNums[0]));
            consulta.Parameters.Add(new OleDbParameter("id2", randomNums[1]));
            consulta.Parameters.Add(new OleDbParameter("id4", randomNums[3]));
            consulta.Parameters.Add(new OleDbParameter("id3", randomNums[2]));
            consulta.Parameters.Add(new OleDbParameter("id5", randomNums[4]));
            consulta.Parameters.Add(new OleDbParameter("id6", randomNums[5]));
            consulta.Parameters.Add(new OleDbParameter("id7", randomNums[6]));
            consulta.Parameters.Add(new OleDbParameter("id8", randomNums[7]));

            OleDbDataReader drConsulta = consulta.ExecuteReader();
            while (drConsulta.Read())
            {
                Food oFood = new Food();
                oFood.Nombre = drConsulta["Palabra"].ToString();
                oFood.Ruta = drConsulta["Imagen"].ToString();
                ListaFood.Add(oFood);
            }
            conexion.Close();
            return ListaFood;
        }

        private int[] selecRandom()
        {
            int rnd;
            for (int i = 0; i < 8; i++)
            {
                rnd = random.Next(1, 21);
                while (randomNums.Contains(rnd))
                {
                    rnd = random.Next(1, 21);
                }
                randomNums[i] = rnd;
            }
            return randomNums;
        }
    }
}
