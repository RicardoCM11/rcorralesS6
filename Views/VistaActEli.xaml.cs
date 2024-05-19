
using rcorralesS6.Models;
using System.Net;
using System.Text;

namespace rcorralesS6.Views;

public partial class VistaActEli : ContentPage
{
	public VistaActEli(Estudiante datos)
	{
		InitializeComponent();
        txtcodigo.Text = datos.codigo.ToString();
        txtnombre.Text = datos.nombre;
        txtapellido.Text = datos.apellido;
        txtedad.Text = datos.edad.ToString();
	}

    private void btnactualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            cliente.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            string parametros = $"codigo={txtcodigo.Text}&nombre={txtnombre.Text}&apellido={txtapellido.Text}&edad={txtedad.Text}";

            cliente.UploadString("http://192.168.100.4/moviles/wsestudiantes.php", "PUT", parametros);

            Navigation.PushAsync(new VistaEstudiante());
        }
        catch (Exception es)
        {
            DisplayAlert("Alerta", es.Message, "Cerrar");
        }

    }

    private void btneliminar_Clicked(object sender, EventArgs e)

    
   {
        try
        {
            string codigoEliminar = txtcodigo.Text;

            WebClient cliente = new WebClient();
            var eliminar = new  System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.100.4/moviles/wsestudiantes.php?codigo=" + codigoEliminar, "DELETE",eliminar);
            
            DisplayAlert("Alerta", "Registro eliminado correctamente", "Aceptar");
            Navigation.PushAsync(new VistaEstudiante());
            
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}


			