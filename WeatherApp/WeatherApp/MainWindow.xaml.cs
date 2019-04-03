using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;

namespace WeatherApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		const string APPID = "505ed5f2695f504e33eeadd684d53537";
		string cityName = "";

		public MainWindow()
		{
			InitializeComponent();
			getForecast("Novi+Sad");
			getWeather("Novi+Sad");
		}
	
		void getForecast(string city) {
			// city = Novi+Sad
			using (WebClient webClient = new WebClient()) {
				string url = ($"http://api.openweathermap.org/data/2.5/forecast?q={city}&appid={APPID}");

				var json = webClient.DownloadString(url);
				//textBlock.Text = json;
				var result = JsonConvert.DeserializeObject<Forecast.root>(json);

			}
		}

		void getWeather(string city)
		{
			// city = Novi+Sad
			using (WebClient webClient = new WebClient())
			{
				string url = ($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={APPID}");

				var json = webClient.DownloadString(url);
				//textBlock.Text = json;
				var result = JsonConvert.DeserializeObject<Weather.root>(json);

			}
		}
	}
}
