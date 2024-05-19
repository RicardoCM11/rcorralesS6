using Newtonsoft.Json;
using rcorralesS6.Models;
using System.Collections.ObjectModel;

namespace rcorralesS6.Views;

public partial class VistaEstudiante : ContentPage
{

	private const string url = "http://192.168.100.4/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> est;
	public VistaEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();
	}

	public async void ObtenerDatos()
	{
		var content = await cliente.GetStringAsync(url);
		List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		est = new ObservableCollection<Estudiante>(mostrar);
		Listaestudiantes.ItemsSource = est;
	}

    private void btnagregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new VistaAgregar());

    }

    private void Listaestudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new VistaActEli(objEstudiante));
    }
}