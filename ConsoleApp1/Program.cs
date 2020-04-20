using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.IO;
using System.Net;
using RestSharp.Serialization.Xml;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.IdentityModel.Tokens.Jwt;


namespace ConsoleApp1
{
    class Program
    {

		static void Main(string[] args)
		{
			var clientWeather = new RestClient("http://api.worldweatheronline.com/premium/v1/weather.ashx");//?key=c37f984779f14beb9bf01943201104&q=Pristina&format=json&num_of_days=5");
																											//client.Timeout = -1;
			var requestWeather = new RestRequest(Method.GET);
			requestWeather.AddParameter("key", "c37f984779f14beb9bf01943201104", ParameterType.QueryString);
			requestWeather.AddParameter("q", "Pristina", ParameterType.QueryString);
			requestWeather.AddParameter("format", "xml", ParameterType.QueryString);
			requestWeather.AddParameter("num_of_days", "5", ParameterType.QueryString);
			IRestResponse responseWeather = clientWeather.Execute(requestWeather);

			var xmlDeserializer = new XmlDeserializer();
			var place = xmlDeserializer.Deserialize<Request>(responseWeather);
			var temp = xmlDeserializer.Deserialize<Current_condition>(responseWeather);
			var dit = xmlDeserializer.Deserialize<List<Weather>>(responseWeather);

			
			

			Console.WriteLine("Vendi: " + place.Query);
			Console.WriteLine("Temp momentale: " + temp.Temp_C);
			Console.WriteLine("Feel Like: " + temp.FeelsLikeC + "C");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Temperatura per ditet e ardhshme");
		
			Console.Write("Date		" + "TempMin	" );
			Console.WriteLine("TempMax");

			foreach (var result in dit)
			{
				Console.WriteLine(result.Date + "      " + result.MintempC +"C" + "	  " + result.MaxtempC + "C");
			}


			Console.ReadLine();
		}





		[XmlRoot(ElementName = "request")]
		public class Request
		{
			[XmlElement(ElementName = "type")]
			public string Type { get; set; }
			[XmlElement(ElementName = "query")]
			public string Query { get; set; }
		}

		[XmlRoot(ElementName = "current_condition")]
		public class Current_condition
		{
			[XmlElement(ElementName = "observation_time")]
			public string Observation_time { get; set; }
			[XmlElement(ElementName = "temp_C")]
			public string Temp_C { get; set; }
			[XmlElement(ElementName = "temp_F")]
			public string Temp_F { get; set; }
			[XmlElement(ElementName = "weatherCode")]
			public string WeatherCode { get; set; }
			[XmlElement(ElementName = "weatherIconUrl")]
			public string WeatherIconUrl { get; set; }
			[XmlElement(ElementName = "weatherDesc")]
			public string WeatherDesc { get; set; }
			[XmlElement(ElementName = "windspeedMiles")]
			public string WindspeedMiles { get; set; }
			[XmlElement(ElementName = "windspeedKmph")]
			public string WindspeedKmph { get; set; }
			[XmlElement(ElementName = "winddirDegree")]
			public string WinddirDegree { get; set; }
			[XmlElement(ElementName = "winddir16Point")]
			public string Winddir16Point { get; set; }
			[XmlElement(ElementName = "precipMM")]
			public string PrecipMM { get; set; }
			[XmlElement(ElementName = "precipInches")]
			public string PrecipInches { get; set; }
			[XmlElement(ElementName = "humidity")]
			public string Humidity { get; set; }
			[XmlElement(ElementName = "visibility")]
			public string Visibility { get; set; }
			[XmlElement(ElementName = "visibilityMiles")]
			public string VisibilityMiles { get; set; }
			[XmlElement(ElementName = "pressure")]
			public string Pressure { get; set; }
			[XmlElement(ElementName = "pressureInches")]
			public string PressureInches { get; set; }
			[XmlElement(ElementName = "cloudcover")]
			public string Cloudcover { get; set; }
			[XmlElement(ElementName = "FeelsLikeC")]
			public string FeelsLikeC { get; set; }
			[XmlElement(ElementName = "FeelsLikeF")]
			public string FeelsLikeF { get; set; }
			[XmlElement(ElementName = "uvIndex")]
			public string UvIndex { get; set; }
		}

		[XmlRoot(ElementName = "astronomy")]
		public class Astronomy
		{
			[XmlElement(ElementName = "sunrise")]
			public string Sunrise { get; set; }
			[XmlElement(ElementName = "sunset")]
			public string Sunset { get; set; }
			[XmlElement(ElementName = "moonrise")]
			public string Moonrise { get; set; }
			[XmlElement(ElementName = "moonset")]
			public string Moonset { get; set; }
			[XmlElement(ElementName = "moon_phase")]
			public string Moon_phase { get; set; }
			[XmlElement(ElementName = "moon_illumination")]
			public string Moon_illumination { get; set; }
		}

		[XmlRoot(ElementName = "hourly")]
		public class Hourly
		{
			[XmlElement(ElementName = "time")]
			public string Time { get; set; }
			[XmlElement(ElementName = "tempC")]
			public string TempC { get; set; }
			[XmlElement(ElementName = "tempF")]
			public string TempF { get; set; }
			[XmlElement(ElementName = "windspeedMiles")]
			public string WindspeedMiles { get; set; }
			[XmlElement(ElementName = "windspeedKmph")]
			public string WindspeedKmph { get; set; }
			[XmlElement(ElementName = "winddirDegree")]
			public string WinddirDegree { get; set; }
			[XmlElement(ElementName = "winddir16Point")]
			public string Winddir16Point { get; set; }
			[XmlElement(ElementName = "weatherCode")]
			public string WeatherCode { get; set; }
			[XmlElement(ElementName = "weatherIconUrl")]
			public string WeatherIconUrl { get; set; }
			[XmlElement(ElementName = "weatherDesc")]
			public string WeatherDesc { get; set; }
			[XmlElement(ElementName = "precipMM")]
			public string PrecipMM { get; set; }
			[XmlElement(ElementName = "precipInches")]
			public string PrecipInches { get; set; }
			[XmlElement(ElementName = "humidity")]
			public string Humidity { get; set; }
			[XmlElement(ElementName = "visibility")]
			public string Visibility { get; set; }
			[XmlElement(ElementName = "visibilityMiles")]
			public string VisibilityMiles { get; set; }
			[XmlElement(ElementName = "pressure")]
			public string Pressure { get; set; }
			[XmlElement(ElementName = "pressureInches")]
			public string PressureInches { get; set; }
			[XmlElement(ElementName = "cloudcover")]
			public string Cloudcover { get; set; }
			[XmlElement(ElementName = "HeatIndexC")]
			public string HeatIndexC { get; set; }
			[XmlElement(ElementName = "HeatIndexF")]
			public string HeatIndexF { get; set; }
			[XmlElement(ElementName = "DewPointC")]
			public string DewPointC { get; set; }
			[XmlElement(ElementName = "DewPointF")]
			public string DewPointF { get; set; }
			[XmlElement(ElementName = "WindChillC")]
			public string WindChillC { get; set; }
			[XmlElement(ElementName = "WindChillF")]
			public string WindChillF { get; set; }
			[XmlElement(ElementName = "WindGustMiles")]
			public string WindGustMiles { get; set; }
			[XmlElement(ElementName = "WindGustKmph")]
			public string WindGustKmph { get; set; }
			[XmlElement(ElementName = "FeelsLikeC")]
			public string FeelsLikeC { get; set; }
			[XmlElement(ElementName = "FeelsLikeF")]
			public string FeelsLikeF { get; set; }
			[XmlElement(ElementName = "chanceofrain")]
			public string Chanceofrain { get; set; }
			[XmlElement(ElementName = "chanceofremdry")]
			public string Chanceofremdry { get; set; }
			[XmlElement(ElementName = "chanceofwindy")]
			public string Chanceofwindy { get; set; }
			[XmlElement(ElementName = "chanceofovercast")]
			public string Chanceofovercast { get; set; }
			[XmlElement(ElementName = "chanceofsunshine")]
			public string Chanceofsunshine { get; set; }
			[XmlElement(ElementName = "chanceoffrost")]
			public string Chanceoffrost { get; set; }
			[XmlElement(ElementName = "chanceofhightemp")]
			public string Chanceofhightemp { get; set; }
			[XmlElement(ElementName = "chanceoffog")]
			public string Chanceoffog { get; set; }
			[XmlElement(ElementName = "chanceofsnow")]
			public string Chanceofsnow { get; set; }
			[XmlElement(ElementName = "chanceofthunder")]
			public string Chanceofthunder { get; set; }
			[XmlElement(ElementName = "uvIndex")]
			public string UvIndex { get; set; }
		}

		[XmlRoot(ElementName = "weather")]
		public class Weather
		{
			[XmlElement(ElementName = "date")]
			public string Date { get; set; }
			[XmlElement(ElementName = "astronomy")]
			public Astronomy Astronomy { get; set; }
			[XmlElement(ElementName = "maxtempC")]
			public string MaxtempC { get; set; }
			[XmlElement(ElementName = "maxtempF")]
			public string MaxtempF { get; set; }
			[XmlElement(ElementName = "mintempC")]
			public string MintempC { get; set; }
			[XmlElement(ElementName = "mintempF")]
			public string MintempF { get; set; }
			[XmlElement(ElementName = "avgtempC")]
			public string AvgtempC { get; set; }
			[XmlElement(ElementName = "avgtempF")]
			public string AvgtempF { get; set; }
			[XmlElement(ElementName = "totalSnow_cm")]
			public string TotalSnow_cm { get; set; }
			[XmlElement(ElementName = "sunHour")]
			public string SunHour { get; set; }
			[XmlElement(ElementName = "uvIndex")]
			public string UvIndex { get; set; }
			[XmlElement(ElementName = "hourly")]
			public List<Hourly> Hourly { get; set; }
		}

		[XmlRoot(ElementName = "month")]
		public class Month
		{
			[XmlElement(ElementName = "index")]
			public string Index { get; set; }
			[XmlElement(ElementName = "name")]
			public string Name { get; set; }
			[XmlElement(ElementName = "avgMinTemp")]
			public string AvgMinTemp { get; set; }
			[XmlElement(ElementName = "avgMinTemp_F")]
			public string AvgMinTemp_F { get; set; }
			[XmlElement(ElementName = "absMaxTemp")]
			public string AbsMaxTemp { get; set; }
			[XmlElement(ElementName = "absMaxTemp_F")]
			public string AbsMaxTemp_F { get; set; }
			[XmlElement(ElementName = "avgDailyRainfall")]
			public string AvgDailyRainfall { get; set; }
		}

		[XmlRoot(ElementName = "ClimateAverages")]
		public class ClimateAverages
		{
			[XmlElement(ElementName = "month")]
			public List<Month> Month { get; set; }
		}

		[XmlRoot(ElementName = "data")]
		public class Data
		{
			[XmlElement(ElementName = "request")]
			public Request Request { get; set; }
			[XmlElement(ElementName = "current_condition")]
			public Current_condition Current_condition { get; set; }
			[XmlElement(ElementName = "weather")]
			public List<Weather> Weather { get; set; }
			[XmlElement(ElementName = "ClimateAverages")]
			public ClimateAverages ClimateAverages { get; set; }
		}


	}
}
