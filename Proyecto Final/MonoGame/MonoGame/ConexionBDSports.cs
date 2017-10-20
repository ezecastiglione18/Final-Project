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

            OleDbDataReader drConsulta = consulta.ExecuteReader();
            while (drConsulta.Read())
            {
                Sports oSports = new Sports();
                oSports.Nombre = drConsulta["Text1"].ToString();
                oSports.Id = Convert.ToInt32(drConsulta["Id1"]);
                oSports.Identificador = Convert.ToInt32(drConsulta["ident1"]);
                ListaSports.Add(oSports);

                oSports = new Sports();
                oSports.Nombre = drConsulta["Text2"].ToString();
                oSports.Id = Convert.ToInt32(drConsulta["Id2"]);
                oSports.Identificador = Convert.ToInt32(drConsulta["ident2"]);
                ListaSports.Add(oSports);
            }
            conexion.Close();
            return ListaSports;
        }
    }
}
