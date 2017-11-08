using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_Examen
{
    //Gemaakt via de "paste special" tool voor Visual Studio 2017 RC verdere informatie terug te vinden in de conclusie van het testrapport
        public class Sproeiers
        {
            public Sproeierss[] Sproeier { get; set; }
        }

        public class Sproeierss
        {
            public int teeltbed { get; set; }
            public float waarde { get; set; }
            public float hoog { get; set; }
            public float laag { get; set; }
            public bool status { get; set; }
        }
}
