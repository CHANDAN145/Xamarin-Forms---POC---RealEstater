using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace RealEstater
{
	public partial class SelectedItemPage : ContentPage
	{
		const string basicInfoUrl = "https://sample-listings.herokuapp.com/listings/";
		const string domainUrl = "https://sample-listings.herokuapp.com";

		public SelectedItemPage (House selectedHouse)
		{
			InitializeComponent ();

			resultPageStackView.Padding = new Thickness (10, 20, 10, 4);
			houseImage.Source = selectedHouse.Image;
			houseImage.HeightRequest = 175;

			var selectedHouseUrl = basicInfoUrl + selectedHouse.ListingID;
			var taskReadJSON = Task.Run (
				async () => {
					var result = await JSONDownloader.DownloadSerializedJSONDataAsync<House> (selectedHouseUrl);
					selectedHouse = result;
				});
			taskReadJSON.Wait ();

			pageTitle.Text = selectedHouse.Address;
			numberOfBeds.Text = "Beds: " + selectedHouse.Beds + ",";
			numberOfBeds.FontSize = 10;

			numberOfBaths.Text = "Baths: " + selectedHouse.Baths + ",";
			numberOfBaths.FontSize = 10;

			houseAddress.Text = selectedHouse.Address;
			houseAddress.FontSize = 10;

			ChangeOverLastYear.Text = selectedHouse.ChangeOverLastYear + "%";
			Double changeOverlastYearTemp = Double.Parse(selectedHouse.ChangeOverLastYear);
			ChangeOverLastYear.FontSize = 10;
			if (changeOverlastYearTemp < 0)
				ChangeOverLastYear.TextColor = Color.Red;
			else
				ChangeOverLastYear.TextColor = Color.Green;
			
			houseFeatures.Text = selectedHouse.Features;
			houseFeatures.FontSize = 10;

			houseEstimatedValue.Text = "$"+ selectedHouse.EstimatedValue + ",";
			houseEstimatedValue.FontSize = 10;

			backNavigationButton.IsVisible = Device.OnPlatform (true, false, false);
			backNavigationButton.Clicked += (sender, args) => {
				Navigation.PushModalAsync (new HouseListPage ());
			};
		}
	}
}

