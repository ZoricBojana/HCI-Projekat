using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace WeatherApp
{
	class Bookmark //: INotifyPropertyChanged
	{
		/*public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}*/

		public List<string> BookmarkItems { get; set; }

		public Bookmark()
		{
			BookmarkItems = new List<string>();

			using (StreamReader sr = new StreamReader("bookmark.txt"))
			{
				string item;
				while ((item = sr.ReadLine()) != null)
				{
					BookmarkItems.Add(item);
				}
			}

		}

		public bool AddItem(string item)
		{

			BookmarkItems.Add(item);
			WriteToFile();

			return true;
		}

		public bool RemoveItem(string item)
		{
			BookmarkItems.Remove(item);
			WriteToFile();
			return true;
		}

		public bool EmptyBookmark()
		{
			BookmarkItems.Clear();
			WriteToFile();
			return true;
		}

		public void WriteToFile()
		{
			using (StreamWriter writer = new StreamWriter("bookmark.txt"))
			{
				foreach (string s in BookmarkItems)
				{
					writer.WriteLine(s);
				}
			}
		}

		public string MakeString()
		{
			string str = "";
			foreach (string s in BookmarkItems)
			{
				str += s + " ";
			}
			return str;
		}
	}
}
