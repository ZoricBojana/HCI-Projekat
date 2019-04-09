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


		Bookmark bookmark;
		History history;

		public MainWindow()
		{
			InitializeComponent();

			//*******dodaj elemente
			bookmark = new Bookmark();
			foreach (string el in bookmark.BookmarkItems)
			{
				MenuItem mItem = new MenuItem();
				mItem.Name = el.Replace(" ", "_");
				mItem.Header = el;
				mItem.Click+= MenuItem_Click;
				bookmarkMenu.Items.Add(mItem);
			}
			//******

			//*******dodaj elemente
			history = new History();
			foreach (string el in history.HistoryItems)
			{
				MenuItem mItem = new MenuItem();
				mItem.Name = el.Replace(" ", "_");
				mItem.Header = el;
				mItem.Click += MenuItem_Click;
				historyMenu.Items.Add(mItem);
			}
			//******

			getLocation(); // smesta lokaciju u cityName
			getForecast(cityName);
			getWeather(cityName);

			//lbl_updated.Content = ("Azurirano: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
		}


		void getForecast(string city) {
			lbl_updated.Content = ("Azurirano: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			// city = Novi+Sad
			using (WebClient webClient = new WebClient()) {
				string url = ($"http://api.openweathermap.org/data/2.5/forecast?q={city}&appid={APPID}");

				var json = webClient.DownloadString(url);
				//textBlock.Text = json;
				var result = JsonConvert.DeserializeObject<Forecast.root>(json);
				Forecast.root output = result;

				//var day1 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

				

				Dictionary<string, List<Forecast.list> > dict = new Dictionary<string, List<Forecast.list> >();

				for (int i = 0; i < 5; i++) {
					var dayx = DateTime.Now.AddDays(i+1).ToString("yyyy-MM-dd");
                    var date = DateTime.Now.AddDays(i + 1).ToString("dd/MM/yyyy");
                    foreach (var d in output.list) {
						if (d.dt_txt.Contains(dayx)) {
							if (!dict.ContainsKey(date)) {
								dict[date] = new List<Forecast.list>();
							}
          
							dict[date].Add(d);
						}
					}
				}
				//***** day1
				var day1 = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
				double min_temp = 100;
				double max_temp = -50;
				//int br = 0;

				foreach (var el in dict[day1]) {
					double temp = el.main.temp - 273.15;

					if (el.dt_txt.Contains("12:00:00")) {
						day1Icon.Source = new BitmapImage(new Uri("/images/" + el.weather[0].icon + ".png", UriKind.Relative));
					}

					if (temp < min_temp) {
						min_temp = temp;
					}
					if (temp > max_temp)
					{
						max_temp = temp;
					}
				}

				day1temp.Content = "Min: " + Math.Floor(min_temp) + "\u00B0C" + "\nMaks: " + Math.Ceiling(max_temp) + "\u00B0C";

				//********* day 2 *****

				var day2 = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy");
				day2Lab.Content = day2;
				min_temp = 100;
				max_temp = -50;

				foreach (var el in dict[day2])
				{
					if (el.dt_txt.Contains("12:00:00"))
					{
						day2Icon.Source = new BitmapImage(new Uri("/images/" + el.weather[0].icon + ".png", UriKind.Relative));
					}

					double temp = el.main.temp - 273.15;
					if (temp < min_temp)
					{
						min_temp = temp;
					}
					if (temp > max_temp)
					{
						max_temp = temp;
					}
				}

				day2temp.Content = "Min: " + Math.Floor(min_temp) + "\u00B0C" + "\nMaks: " + Math.Ceiling(max_temp) + "\u00B0C";

				//********* day 3 *****

				var day3 = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy");
				day3Lab.Content = day3;
				min_temp = 100;
				max_temp = -50;

				foreach (var el in dict[day3])
				{

					if (el.dt_txt.Contains("12:00:00"))
					{
						day3Icon.Source = new BitmapImage(new Uri("/images/" + el.weather[0].icon + ".png", UriKind.Relative));
					}

					double temp = el.main.temp - 273.15;
					if (temp < min_temp)
					{
						min_temp = temp;
					}
					if (temp > max_temp)
					{
						max_temp = temp;
					}
				}

				day3temp.Content = "Min: " + Math.Floor(min_temp) + "\u00B0C" + "\nMaks: " + Math.Ceiling(max_temp) + "\u00B0C";

				//********* day 4 *****

				var day4 = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy");
				day4Lab.Content = day4;
				min_temp = 100;
				max_temp = -50;

				foreach (var el in dict[day4])
				{
					if (el.dt_txt.Contains("12:00:00"))
					{
						day4Icon.Source = new BitmapImage(new Uri("/images/" + el.weather[0].icon + ".png", UriKind.Relative));
					}

					double temp = el.main.temp - 273.15;
					if (temp < min_temp)
					{
						min_temp = temp;
					}
					if (temp > max_temp)
					{
						max_temp = temp;
					}
				}

				day4temp.Content = "Min: " + Math.Floor(min_temp) + "\u00B0C" + "\nMaks: " + Math.Ceiling(max_temp) + "\u00B0C";

				//********* day 5 *****

				var day5 = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy");
				day5Lab.Content = day5;
				min_temp = 100;
				max_temp = -50;

				foreach (var el in dict[day5])
				{
					if (el.dt_txt.Contains("12:00:00"))
					{
						day5Icon.Source = new BitmapImage(new Uri("/images/" + el.weather[0].icon + ".png", UriKind.Relative));
					}

					double temp = el.main.temp - 273.15;
					if (temp < min_temp)
					{
						min_temp = temp;
					}
					if (temp > max_temp)
					{
						max_temp = temp;
					}
				}

				day5temp.Content = "Min: " + Math.Floor(min_temp) + "\u00B0C" + "\nMaks: " + Math.Ceiling(max_temp) + "\u00B0C";

			}
		}


		void getWeather(string city)
		{
			lbl_updated.Content = ("Azurirano: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			// city = Novi+Sad
			lbl_city.Content ="Trenutna temperatura\n      " + city;

			using (WebClient webClient = new WebClient())
			{
				string url = ($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={APPID}");

				var json = webClient.DownloadString(url);
				//textBlock.Text = json;
				var result = JsonConvert.DeserializeObject<Weather.root>(json);
				Weather.root output = result;

				weatherIcon.Source = new BitmapImage(new Uri("/images/" + output.weather[0].icon + ".png", UriKind.Relative));
				lbl_temperature.Content = Math.Round(output.main.temp - 273.15) + "\u00B0C";

                string description = output.weather[0].main;
                switch(description)
                {
                    case "Clouds":
                        description = "Oblacno";
                        break;
                    case "Clear":
                        description = "Vedro";
                        break;
                    case "Sunny":
                        description = "Suncano";
                        break;
   
                }

                description_lbl.Content = "         " +  description;
                

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

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MenuItem menuItem = sender as MenuItem;
			string text = menuItem.Header as string;

			cityName = text;

			getForecast(cityName);
			getWeather(cityName);
		}

		private void Refresh_Click(object sender, RoutedEventArgs e)
		{
			getForecast(cityName);
			getWeather(cityName);
		}

		private void SearchBtn_Click(object sender, RoutedEventArgs e)
		{
			string text = searchTB.Text;
			if (text.Trim() != "")
			{
				cityName = searchTB.Text;
				history.AddItem(cityName);
				MenuItem mItem = new MenuItem();
				mItem.Name = cityName.Replace(" ", "_");
				mItem.Header = cityName;
				mItem.Click += MenuItem_Click;
				historyMenu.Items.Add(mItem);
				getForecast(cityName);
				getWeather(cityName);
			}
		}

		private void BookmarkBtn_Click(object sender, RoutedEventArgs e)
		{
			string text = searchTB.Text;
			if (text.Trim() != "") { 
				bookmark.AddItem(text);

				MenuItem mItem = new MenuItem();
				mItem.Name = text.Replace(" ", "_");
				mItem.Header = text;
				mItem.Click += MenuItem_Click;
				bookmarkMenu.Items.Add(mItem);
			}
		}
	}
}
