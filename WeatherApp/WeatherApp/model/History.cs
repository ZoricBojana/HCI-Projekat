using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherApp
{
	class History
	{
		public List<string> HistoryItems { get; set; }

		public History()
		{
			HistoryItems = new List<string>();

			using (StreamReader sr = new StreamReader("history.txt"))
			{
				string item;
				while ((item = sr.ReadLine()) != null)
				{
					HistoryItems.Add(item);
				}
			}
		}

		public bool AddItem(string item)
		{

			HistoryItems.Add(item);
			WriteToFile();

			return true;
		}

		public bool RemoveItem(string item)
		{
			HistoryItems.Remove(item);
			WriteToFile();
			return true;
		}

		public bool EmptyHistory()
		{
			HistoryItems.Clear();
			WriteToFile();
			return true;
		}

		public void WriteToFile()
		{
			using (StreamWriter writer = new StreamWriter("history.txt"))
			{
				foreach (string s in HistoryItems)
				{
					writer.WriteLine(s);
				}
			}
		}

		public string MakeString()
		{
			string str = "";
			foreach (string s in HistoryItems)
			{
				str += s + " ";
			}
			return str;
		}

	}
}
