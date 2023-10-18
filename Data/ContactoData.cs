using PracticaCrud_MisaelSarabia.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Components.Web;
using System.Linq.Expressions;

namespace PracticaCrud_MisaelSarabia.Data
{
    public class ContactoData
    {
        public List<ContactoModel> GetContacts() 
        {
            List<ContactoModel> contactList = new List<ContactoModel>();
            var connection = new Conexion();
            using (var dbConnection = new SqlConnection(connection.ConnectionString())) 
            {
                dbConnection.Open();
                SqlCommand sqlCommand= new SqlCommand("sp_listarContacto", dbConnection);
                sqlCommand.CommandType= CommandType.StoredProcedure;
                
                using(var dr=sqlCommand.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        contactList.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString()
                        });
                    }
                }
            }
            return contactList;
        }

        public ContactoModel GetContactById(int IdContacto) 
        {
            var contact = new ContactoModel();
            var connection = new Conexion();

            using (var dbConnection = new SqlConnection(connection.ConnectionString())) 
            {
                dbConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("sp_Obtener", dbConnection);
                sqlCommand.Parameters.AddWithValue("IdContacto", IdContacto);
                sqlCommand.CommandType= CommandType.StoredProcedure;
                using (var dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        contact.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        contact.Nombre = dr["Nombre"].ToString();
                        contact.Telefono = dr["Telefono"].ToString();
                        contact.Correo = dr["Correo"].ToString();
                        contact.Clave = dr["Clave"].ToString();
                    }
                }
                return contact;
            }

        }


        public bool SaveContact(ContactoModel model)
        {
       
            bool response;
            try
            {
                var dbConnection = new Conexion();
         
                using (var conexion = new SqlConnection(dbConnection.ConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
             
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Clave", model.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;
     
                    cmd.ExecuteNonQuery();
      
                    response = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                response = false;
            }
            return response;
        }

        public bool EditContact(ContactoModel model)
        {

            bool response;
            try
            {
                var dbConnection = new Conexion();

                using (var conexion = new SqlConnection(dbConnection.ConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarContacto", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", model.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Clave", model.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    response = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                response = false;
            }
            return response;
        }

        public bool DeleteContact(int IdContacto) 
        {
            bool response;

            try 
            {
                var connection = new Conexion();

                using (var dbConnection = new SqlConnection(connection.ConnectionString())) 
                {
                    dbConnection.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarContacto", dbConnection);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch(Exception e) 
            {
                string error = e.Message;
                response = false;
            }
            return response;
        }

    }
}
