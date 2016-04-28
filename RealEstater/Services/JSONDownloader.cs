using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace RealEstater
{
	public class JSONDownloader 
	{
		public static async Task<T> DownloadSerializedJSONDataAsync<T>(string url) where T: new()
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
				var jsonData = string.Empty;
				try
				{
					jsonData = await httpClient.GetStringAsync(url);
				}
				catch (Exception)
				{
					
				}
				return JsonConvert.DeserializeObject<T>(jsonData);
			}
		}

	}
}


