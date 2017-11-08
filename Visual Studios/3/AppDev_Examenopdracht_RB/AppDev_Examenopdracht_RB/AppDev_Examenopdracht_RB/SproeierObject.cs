using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_Examen
{
    //Gemaakt via de "paste special" tool voor Visual Studio 2017 RC
    public class SproeierObject
    {
        public Sproeier[] sproeiers { get; set; }
    }

    public class Sproeier
    {
        public int teeltbed { get; set; }
        public float waarde { get; set; }
        public float hoog { get; set; }
        public float laag { get; set; }
        public bool status { get; set; }
    }
}
