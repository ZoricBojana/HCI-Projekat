using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
	class Forecast
	{

		public class main
		{
			public double temp { get; set; }
			public double temp_min { get; set; }
			public double temp_max { get; set; }
			public double pressure { get; set; }
			public double sea_level { get; set; }
			public double grnd_level { get; set; }
			public double humidity { get; set; }
			public double temp_kf { get; set; }
		}

		public class weather {
			public int id { get; set; }
			public string main { get; set; }
			public string description { get; set; }
			public string icon { get; set; }
		}

		public class clouds
		{
			public double all { get; set; }
		}

		public class wind
		{
			public double speed { get; set; }
			public double deg { get; set; }
		}

		public class rain
		{
			[JsonProperty(PropertyName = "3h")]
			public double h { get; set; }
		}

		public class sys
		{
			public string pod { get; set; }
		}

		public class list
		{
			public int dt { get; set; }
			public string dt_txt { get; set; }
			public main main { get; set; }
			public List<weather> weather { get; set; }
			public clouds clouds { get; set; }
			public wind wind { get; set; }
			public sys sys { get; set; }
		}

		public class coord
		{
			public double lat { get; set; }
			public double lon { get; set; }
		}

		public class city {
			public int id { get; set; }
			public string name { get; set; }
			public coord coord { get; set; }
			public string country { get; set; }
			public int population { get; set; }
		}

		public class root
		{
			public string cod { get; set; }
			public string message { get; set; }
			public int cnt { get; set; }
			//[JsonProperty(PropertyName = "list")]
			public List<list> list { get; set; }
			public city city { get; set; }
		}
	}
}
