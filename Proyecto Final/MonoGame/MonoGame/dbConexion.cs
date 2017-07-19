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
        public void abrirConexion()
        {
            conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|Animales.mdb");
            conexion.Open();
            consulta = conexion.CreateCommand();
        }

        public List<Animal> Seleccionar()
        {
            abrirConexion();
            consulta.CommandType = CommandType.Text;
            consulta.CommandText = "SELECT Top 6 * FROM   (SELECT *, Rnd(ID) AS RandomValue FROM Animales) ORDER BY RandomValue ";
            OleDbDataReader drConsulta = consulta.ExecuteReader();
            while (drConsulta.Read())
            {
                Animal oAnimal = new Animal();
                oAnimal.sonido = drConsulta["sonido"].ToString();
                oAnimal.imagen = drConsulta["imagen"].ToString();
                oAnimal.ancho = Convert.ToInt32(drConsulta["ancho"]);
                listAnimales.Add(oAnimal);
            }
            conexion.Close();
            return listAnimales;
        }
    }
}

