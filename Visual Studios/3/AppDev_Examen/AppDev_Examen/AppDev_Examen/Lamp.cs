using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_Examen
{
    class lamp
    {
        public int TeeltBed { get; set; }
        public int Actueel { get; set; }
        public int Hoog { get; set; }
        public int Laag { get; set; }

        public lamp(int teeltbed, int hoog, int laag, int actueel)
        {
            TeeltBed = teeltbed;
            Hoog = hoog;
            Laag = laag;
            Actueel = actueel;
        }
    }
}
