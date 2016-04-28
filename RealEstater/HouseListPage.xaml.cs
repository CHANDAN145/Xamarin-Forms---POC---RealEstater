using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RealEstater
{
	public partial class HouseListPage : ContentPage
	{
		List<House> houses = new List<House> ();
		const string basicInfoUrl = "https://sample-listings.herokuapp.com/listings/";
		const string domainUrl = "https://sample-listings.herokuapp.com";
		ListView listView;
		DataTemplate cell = new DataTemplate (typeof(ImageCell));
		Label header;

		public HouseListPage ()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			var taskReadJSON = Task.Run (
				                   async () => {
					var result = await JSONDownloader.DownloadSerializedJSONDataAsync<List<House>> (basicInfoUrl);
					houses = result;
				});
			taskReadJSON.Wait ();
			houses = imageLinkChanger ();

			var label = new Label ();
			label.Text = "Listings";
			label.Font = Font.SystemFontOfSize (35);
			label.HorizontalOptions = LayoutOptions.Center;
			header = label;

			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);
			cell.SetBinding (TextCell.TextProperty, "Address");
			cell.SetBinding (TextCell.DetailProperty, "Features");
			cell.SetBinding (ImageCell.ImageSourceProperty, "Image");

			listView = new ListView {
				ItemsSource = houses,
				ItemTemplate = cell // Set the ImageCell to the item template for the listview
			};

			this.Content = new StackLayout {
				Children = {
					header,
					listView
				}
			};

			listView.ItemTapped += (sender, args) => {
				var selectedHouse = args.Item;
				Navigation.PushModalAsync (new SelectedItemPage ((House)selectedHouse));
			};
		}

		public List<House> imageLinkChanger ()
		{
			List<House> newHouses = new List<House> ();
			foreach (House house in houses)
			{
				house.Image = domainUrl + house.Image;
				house.Features = "Beds: " + house.Beds + ", Baths: " + house.Baths;
				newHouses.Add (house);
			}
			return newHouses;
		}
	}
}

