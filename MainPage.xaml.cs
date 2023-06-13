using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using LlamadaAPI_FV.Models;

namespace LlamadaAPI_FV
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnGetWeatherClicked_FV(object sender, EventArgs e)
		{
			string latitud = lat.Text;
			string longitud = lon.Text;
			using (var client = new HttpClient())
			{
				var url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=b38b088d763540077b3d8b761d728f15";

				var response = client.GetAsync(url).Result;
				if (response.IsSuccessStatusCode)
				{
					string content = response.Content.ReadAsStringAsync().Result;
					var weatherData = JsonConvert.DeserializeObject<Clima_FV>(content);
					weatherLabel.Text = weatherData.weather[0].description;
					Pais.Text = weatherData.sys.country;
					Ciudad.Text = weatherData.name;
				}
			}
		}
	}
}


