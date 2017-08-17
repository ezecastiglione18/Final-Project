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
    class dbConexion
    {
        public OleDbConnection conexion;
        public OleDbCommand consulta;
        public List<Animal> listAnimales = new List<Animal>();
        Random random = new Random();
        public int[] randomNums = new int [] {7,7,7,7,7,7};
        public void abrirConexion()
        {
            conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|Animales.mdb");
            conexion.Open();
            consulta = conexion.CreateCommand();
        }

        public List<Animal> Seleccionar()
        {
            abrirConexion();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "Consulta1";
            selecRandom();
            consulta.Parameters.Add(new OleDbParameter("id1", randomNums[0]));
            consulta.Parameters.Add(new OleDbParameter("id2", randomNums[1]));
            consulta.Parameters.Add(new OleDbParameter("id4", randomNums[2]));
            consulta.Parameters.Add(new OleDbParameter("id3", randomNums[3]));
            consulta.Parameters.Add(new OleDbParameter("id5", randomNums[4]));
            consulta.Parameters.Add(new OleDbParameter("id6", randomNums[5]));
            OleDbDataReader drConsulta = consulta.ExecuteReader();
            while (drConsulta.Read())
            {
                Animal oAnimal = new Animal();
                oAnimal.sonido = drConsulta["sonido"].ToString();
                oAnimal.imagen = drConsulta["imagen"].ToString();
                oAnimal.ancho = Convert.ToInt32(drConsulta["ancho"]);
                oAnimal.alto = Convert.ToInt32(drConsulta["alto"]);
                listAnimales.Add(oAnimal);
            }
            conexion.Close();
            return listAnimales;
        }

        private int[] selecRandom()
        {
            int rnd = 7;
            for (int i = 0; i < 6; i++)
            {
                rnd = random.Next(1,31);
                while (randomNums.Contains(rnd))
                {
                    rnd = random.Next(1,31);
                }
                randomNums[i] = rnd;
            }
            return randomNums;
        }
    }
}

