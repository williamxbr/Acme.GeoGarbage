using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Acme.GeoGarbage.Utilidades
{
    public static class Utils
    {
        private const string BaseUrL =
            "https://api-il.traffilog.com/";

        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                   && Comparer<T>.Default.Compare(item, end) <= 0;
        }

        public static List<T> RetornaListaAPI<T>(string request)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(BaseUrL) };
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = client
                .PostAsync("appengine_3/5E1DCD81-5138-4A35-B271-E33D71FFFFD9/1/json", content).Result;
            if (response.IsSuccessStatusCode)
            {
                HttpContent resposta = response.Content;
                var retorno = WebUtility.UrlDecode(resposta.ReadAsStringAsync().Result);
                JObject jsonResultado = JObject.Parse(retorno);
                List<JToken> dataJson = jsonResultado["response"]["properties"]["data"].Children().ToList();
                List<T> dadosApiList = new List<T>();
                foreach (JToken result in dataJson)
                {
                    T dadosAPI = result.ToObject<T>();
                    dadosApiList.Add(dadosAPI);
                }
                return dadosApiList;
            }
            return null;
        }
    }
}
