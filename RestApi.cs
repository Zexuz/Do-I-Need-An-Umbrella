using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

namespace ConsoleApplication1 {

    public class RestApi {

        private const string Url = "http://api.openweathermap.org/data/2.5/forecast";

        public string ApiKey { get; protected set; }
        public string CityName { get; set; }
        public string ContryCode { get; set; }

        public RestApi(string apiKey) {
            ApiKey = apiKey;
        }

        public bool CanMakeRequest() {
            if (string.IsNullOrEmpty(CityName)) return false;
            if (string.IsNullOrEmpty(ContryCode)) return false;

            return true;
        }

        public string GetUrl() {
            return Url;
        }

        public string GetQuery() {
            return $"?q={CityName},{ContryCode}&appid={ApiKey}";
        }

        public string GetFullUrl() {
            return GetUrl() + GetQuery();
        }

        public ApiDataResponse GetResonse() {
            Console.WriteLine(GetFullUrl());

            var webReq = WebRequest.Create(GetFullUrl());
            webReq.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest) webReq).UserAgent =
                "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36";

            var httpResponse = (HttpWebResponse) webReq.GetResponse();

            var data = httpResponse.GetResponseStream();

            var reader = new StreamReader(data);
            var json = reader.ReadToEnd();

            reader.Close();
            httpResponse.Close();


            const string pattern = @"\b3h\b";
            const string replace = "rainfallinthreehours";
            string result = Regex.Replace(json, pattern, replace);

            var response = JsonConvert.DeserializeObject<ApiDataResponse>(result);
            return response;
        }

    }

}