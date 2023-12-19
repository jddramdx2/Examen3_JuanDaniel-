using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_JuanDaniel
{
    public partial class Encuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                GenerarNumeroEncuesta();
            }
        }

        protected void btnEnviarEncuesta_Click(object sender, EventArgs e)
        {
            try
            {
               
                string nombre = txtNombre.Text;
                int edad = Convert.ToInt32(txtEdad.Text);
                string correo = txtCorreo.Text;
                string partido = ddlPartido.SelectedValue;

                
                string connectionString = "Data Source=DESKTOP-F1AKN4R\\SQLEXPRESS01;Initial Catalog=DBExamen3JuanDaniel;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    GenerarNumeroEncuesta();

                    
                    int numeroEncuesta;
                    if (int.TryParse(txtNumeroEncuesta.Text, out numeroEncuesta))
                    {
                        
                        string insertQuery = "INSERT INTO Examen3TablaJuanDaniel (NumeroEncuesta, NombreParticipante, EdadNacimiento, CorreoElectronico, PartidoPolitico) " +
                                            "VALUES (@NumeroEncuesta, @Nombre, @Edad, @Correo, @Partido)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@NumeroEncuesta", numeroEncuesta);
                            cmd.Parameters.AddWithValue("@Nombre", nombre);
                            cmd.Parameters.AddWithValue("@Edad", edad);
                            cmd.Parameters.AddWithValue("@Correo", correo);
                            cmd.Parameters.AddWithValue("@Partido", partido);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Response.Write("El número de encuesta no tiene el formato correcto.");
                    }

                    connection.Close();
                }

               
                GenerarNumeroEncuesta();

                Response.Write("Encuesta enviada con éxito");
            }
            catch (Exception ex)
            {
                Response.Write("Error al enviar la encuesta: " + ex.ToString());
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            
            Response.Write("Reporte generado correctamente");
        }

        private void GenerarNumeroEncuesta()
        {
            try
            {
                
                string connectionString = "Data Source=DESKTOP-F1AKN4R\\SQLEXPRESS01;Initial Catalog=DBExamen3JuanDaniel;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    string query = "SELECT ISNULL(MAX(NumeroEncuesta), 0) + 1 FROM Examen3TablaJuanDaniel";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        txtNumeroEncuesta.Text = cmd.ExecuteScalar().ToString();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error al generar número de encuesta: " + ex.Message);
            }
        }
    }
}