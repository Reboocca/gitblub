using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Les7_Webservice
{
    static class Rest
    {
        static public async Task<List<String>> GetOmroep(string provincie, string omroep)             // 1
        {
            String url = "https://amje.000webhostapp.com/radioJSON.php";
            Uri httprequest = new Uri(url + "?provincie=" + provincie.Trim() + "&omroep=" + omroep.Trim());          // 2        

            HttpClient client = new HttpClient();
            HttpResponseMessage respons = await client.GetAsync(httprequest);      

            respons.EnsureSuccessStatusCode();
            string responsecontent = await respons.Content.ReadAsStringAsync();    

            JObject content = JObject.Parse(responsecontent);                      
            IList<JToken> tokens = content["results"].Children().ToList();         

            List<String> resultaten = new List<String>();
            foreach (JToken token in tokens)
            {
                Naam searchResult =
                            JsonConvert.DeserializeObject<Naam>(token.ToString()); 
                resultaten.Add(searchResult.ToString());
            }
            return resultaten;

        }


        //static public async Task<List<String>> GetNamen(string filter)             // 1
        //{
        //    String url = "https://amje.000webhostapp.com/namenJSON.php";
        //    // String url = "http://localhost:8080/map/webservice/namenJSON.php";
        //    Uri httprequest = new Uri(url + "?letters=" + filter.Trim());          // 2

        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage respons = await client.GetAsync(httprequest);      // 3

        //    respons.EnsureSuccessStatusCode();
        //    string responsecontent = await respons.Content.ReadAsStringAsync();    // 4

        //    JObject content = JObject.Parse(responsecontent);                      // 5
        //    IList<JToken> tokens = content["results"].Children().ToList();         // 6

        //    List<String> resultaten = new List<String>();
        //    foreach (JToken token in tokens)
        //    {
        //        Naam searchResult =
        //        JsonConvert.DeserializeObject<Naam>(token.ToString()); // 7
        //        resultaten.Add(searchResult.ToString());
        //    }
        //    return resultaten;
        //}

    }
}
