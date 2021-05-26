using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BerylCalendar.Models
{
    public class LuisAPI
    {
        public string Source { get; set; }

		public LuisAPI(string endpoint)
        {
			Source = endpoint;
        } 

		/*{
			"query":"create a new appointment called \"hello sean\"",
			"prediction":
			{
				"topIntent":"Calendar.CreateEventWithTitle",
				"intents":
				{
					"Calendar.CreateEventWithTitle":{"score":0.9458488}
				},
				"entities":
				{
					"Title":["hello sean"]
				}
			}
		}*/

		public string LuisListen(){
			string jsonResponse = SendRequest(Source);
			//Debug.WriteLine(jsonResponse);
			return jsonResponse;
		}

        private static string SendRequest(string uri)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.Accept = "application/json";

			string jsonString = null;
			WebResponse response;
			try{
				response = request.GetResponse();
			} catch(WebException e) {
				jsonString = "{'message':'" + e.Message + "','uri':'" + uri + "'}";
				return jsonString;
			}
			using (response)
			{
				Stream stream = response.GetResponseStream();
				StreamReader reader = new StreamReader(stream);
				jsonString = reader.ReadToEnd();
				reader.Close();
				stream.Close();
			}
			return jsonString;
		}
    }
}
