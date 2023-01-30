using ExamenProgreso3.Models;
using Newtonsoft.Json;

namespace ExamenProgreso3;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	public async void Button_Clicked(object sender, EventArgs e)
	{
		
		string cadena = Buscador.Text;
		var request = new HttpRequestMessage();
		request.RequestUri = new Uri("https://randomuser.me/api/" + cadena);
		request.Method = HttpMethod.Get;
		request.Headers.Add("Acept", "application/json");

		var client = new HttpClient();

		HttpResponseMessage response = await client.SendAsync(request);	
		if(response.StatusCode == System.Net.HttpStatusCode.OK)
		{
			string content = await response.Content.ReadAsStringAsync();
			var resultado = JsonConvert.DeserializeObject<List<MVComentario>>(content);
			ListaDemo.ItemsSource = resultado;
		}
    }
}

