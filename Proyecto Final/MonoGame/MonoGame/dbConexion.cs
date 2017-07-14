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
            conexion = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|Base de datos.mdb");
            conexion.Open();
            consulta = conexion.CreateCommand();
        }

        public void Seleccionar(int[] random)
        {
            abrirConexion();
            consulta.CommandType = CommandType.Text;
            consulta.CommandText = "SELECT Top 6 * FROM   (SELECT *, Rnd(ID) AS RandomValue FROM Animales) ORDER BY RandomValue ";
            OleDbDataReader drConsulta = consulta.ExecuteReader();
            /*while (drConsulta.Read())
            {
                listAnimales.Add(drConsulta["Id"].ToString() + "|" + drConsulta["sonido"].ToString() + "|" + drConsulta["imagen"].ToString() + "|" + drConsulta["ancho"].ToString());
            }
            conexion.Close();
            foreach (string an in LLENAR)
            {
                Animal oAnimal = new Animal();
                string[] datos = an.Split('|');
                oAnimal.sonido = datos[0];
                oAnimal.imagen = 
                oAnimal.ancho= datos[3];
                listAnimales.Add(oAnimal);
            }*/
        }
    }
}

