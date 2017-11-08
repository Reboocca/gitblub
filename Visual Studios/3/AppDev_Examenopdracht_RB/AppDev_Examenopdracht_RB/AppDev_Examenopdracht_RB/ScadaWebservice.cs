using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_Examen
{
    static class ScadaWebservice
    {
        const string Webadres = "https://amje.000webhostapp.com/kas/";

        //Haal Sproeier gegevens op en geef een lijst terug
        static public async Task<List<Sproeier>> SproeierInfo()
        {
            //WebAdres = "https://amje.000webhostapp.com/kas/sproeiers.php";
            string Adress = Webadres + "sproeiers.php";

            HttpClient client = new HttpClient();
            HttpResponseMessage respons = await client.GetAsync(Adress);

            respons.EnsureSuccessStatusCode();
            string responsecontent = await respons.Content.ReadAsStringAsync();

            SproeierObject x = JsonConvert.DeserializeObject<SproeierObject>(responsecontent);


            List<Sproeier> SproeierLijst = new List<Sproeier>();

            foreach (Sproeier s in x.sproeiers)
            {
                Sproeier sproeier1 = new Sproeier(s.teeltbed, s.hoog, s.laag);
            }

            return SproeierLijst;
        }

        //Haal Lamp gegevens op en geef lijst terug
        static public async Task<List<Lamp>> LampInfo()
        {
            string Adress = Webadres + "lampen.php";

            HttpClient client = new HttpClient();
            HttpResponseMessage respons = await client.GetAsync(Adress);

            respons.EnsureSuccessStatusCode();
            string responsecontent = await respons.Content.ReadAsStringAsync();

            LampOpbject x = JsonConvert.DeserializeObject<LampOpbject>(responsecontent);

            List<Lamp> LampenLijst = new List<Lamp>();

            foreach (Lamp l in x.lampen)
            {
                Lamp lamp1 = new Lamp(l.teeltbed, l.hoog, l.laag);
            }

            return LampenLijst;
        }
    }
}
