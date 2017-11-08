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
        static public async Task<List<sproeier>> SproeierInfo()
        {
            //WebAdres = "https://amje.000webhostapp.com/kas/sproeiers.php";
            //string Adress = Webadres + "sproeiers.php";

            //HttpClient client = new HttpClient();
            //HttpResponseMessage respons = await client.GetAsync(Adress);

            //Een van de statussen heb ik op "true" gezet om te laten zien dat de code werkt.
            string responsecontent = @"{ ""Sproeier"":[{""teeltbed"":1,""waarde"":80.4035,""hoog"":100,""laag"":50,""status"":true},{""teeltbed"":2,""waarde"":7.0306,""hoog"":7.3,""laag"":5.7,""status"":false},{""teeltbed"":3,""waarde"":7.0883,""hoog"":8.7,""laag"":4.8,""status"":false},{""teeltbed"":4,""waarde"":3.9,""hoog"":6.2,""laag"":3,""status"":false},{""teeltbed"":5,""waarde"":5.8227,""hoog"":6.4,""laag"":5.5,""status"":false},{""teeltbed"":6,""waarde"":6.3471,""hoog"":6.4,""laag"":4.5,""status"":false}]}";



            //  respons.EnsureSuccessStatusCode();
            // string responsecontent = await respons.Content.ReadAsStringAsync();


            Sproeiers x = JsonConvert.DeserializeObject<Sproeiers>(responsecontent);
            

            List<sproeier> SproeierLijst = new List<sproeier>();

            foreach (Sproeierss s in x.Sproeier)
            {
                if(s.status == false)
                {
                    sproeier sproeier1 = new sproeier(s.teeltbed, s.hoog, s.laag, s.waarde, AanUit.Uit);
                    SproeierLijst.Add(sproeier1);
                }
                else if(s.status == true)
                {
                    sproeier sproeier1 = new sproeier(s.teeltbed, s.hoog, s.laag, s.waarde, AanUit.Aan);
                    SproeierLijst.Add(sproeier1);
                }
            }

            return SproeierLijst;
        }

        //Haal Lamp gegevens op en geef lijst terug
        static public async Task<List<lamp>> LampInfo()
        {
            //string Adress = Webadres + "lampen.php";

            //HttpClient client = new HttpClient();
            //HttpResponseMessage respons = await client.GetAsync(Adress);

            //respons.EnsureSuccessStatusCode();
            //string responsecontent = await respons.Content.ReadAsStringAsync();

            string responsecontent1 = @"{""Lamp"":[{""teeltbed"":1,""waarde"":55,""hoog"":150,""laag"":50},{""teeltbed"":2,""waarde"":78,""hoog"":250,""laag"":50},{""teeltbed"":3,""waarde"":100,""hoog"":250,""laag"":100},{""teeltbed"":4,""waarde"":49,""hoog"":134,""laag"":54},{""teeltbed"":5,""waarde"":100,""hoog"":154,""laag"":100},{""teeltbed"":6,""waarde"":90,""hoog"":190,""laag"":85}]}";


            Lampen i = JsonConvert.DeserializeObject<Lampen>(responsecontent1);


            List<lamp> LampenLijst = new List<lamp>();

            foreach (Lampenn l in i.Lamp)
            {
                lamp lamp1 = new lamp(l.teeltbed, l.hoog, l.laag, l.waarde);
                LampenLijst.Add(lamp1);
            }

            return LampenLijst;
        }
    }
}
