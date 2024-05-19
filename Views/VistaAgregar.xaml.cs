using System.Net;

namespace rcorralesS6.Views;

public partial class VistaAgregar : ContentPage
{
	public VistaAgregar()
	{
		InitializeComponent();
	}

    private void btnguardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();	
			parametros.Add("nombre", txtnombre.Text);
			parametros.Add("apellido", txtapellido.Text);
			parametros.Add("edad", txtedad.Text);
			cliente.UploadValues("http://192.168.100.4/moviles/wsestudiantes.php", "POST",parametros);
			Navigation.PushAsync(new VistaEstudiante());
		}
		catch (Exception es)
		{

			DisplayAlert("Alerta", es.Message, "Cerrar");
		}
    }
}