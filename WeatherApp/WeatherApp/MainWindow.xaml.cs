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
		const string APIIP = "0efe5bc2ad27daf51de12523f9c30924";
		string cityName = "";


		History history = new History();
		Bookmark bookmark = new Bookmark();

		public MainWindow()
		{
			InitializeComponent();
			getLocation(); // smesta lokaciju u cityName
			getForecast(cityName);
			getWeather(cityName);

			lbl_updated.Content = ("Azurirano: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
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
				Weather.root output = result;

				weatherIcon.Source = new BitmapImage(new Uri("/images/" + output.weather[0].icon + ".png", UriKind.Relative));
				lbl_temperature.Content = (output.main.temp - 273.15) + "\u00B0C";
			}
		}

		public void getLocation() {
			using (WebClient web = new WebClient())
			{
				var json = web.DownloadString($"http://api.ipstack.com/check?access_key={APIIP}");

				var result = JsonConvert.DeserializeObject<Location>(json);
				cityName = result.city;
				//textBox_search.Text = cityName;
			}
		}

		
	}
}
