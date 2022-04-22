
using Entidades;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class D_Datos
     {
        SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conector"].ConnectionString);

        public void Insertar(C_Entidades info)
        {
            SqlCommand comando = new SqlCommand("SP__Insertando", conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            comando.Parameters.AddWithValue("@Nombre", info.Nombre);
            comando.Parameters.AddWithValue("@Apellido", info.Apellido);
            comando.Parameters.AddWithValue("@Cedula", info.Cedula);
            comando.Parameters.AddWithValue("@Telefono", info.Telefono);
            comando.Parameters.AddWithValue("@Direccion", info.Direccion);
            comando.Parameters.AddWithValue("@Ciudad", info.Ciudad);          
            comando.ExecuteNonQuery();
            conection.Close();
        }
        public List<C_Entidades> ListarInformacion(string buscar)
        {
            SqlDataReader read;
            SqlCommand cdm = new SqlCommand("SP__Buscar", conection);
            cdm.CommandType = CommandType.StoredProcedure;
            conection.Open();
            cdm.Parameters.AddWithValue("@Buscar", buscar);
            read = cdm.ExecuteReader();


            List<C_Entidades> listar = new List<C_Entidades>();

            while (read.Read())
            {
                listar.Add(new C_Entidades
                {


                    Id = read.GetInt32(0),
                    Nombre = read.GetString(2),
                    Apellido = read.GetString(3),
                    Cedula = read.GetString(4),
                    Telefono=read.GetString(5),
                    Direccion = read.GetString(6),
                    Ciudad= read.GetString(7)


                });



            }
            conection.Close();
            read.Close();

            return listar;
        }
        public void Eliminar_Informacion(C_Entidades info)
        {
            SqlCommand comando = new SqlCommand("SP__Delete", conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            comando.Parameters.AddWithValue("@Id", info.Id);


            comando.ExecuteNonQuery();
            conection.Close();

        }
    }
}
