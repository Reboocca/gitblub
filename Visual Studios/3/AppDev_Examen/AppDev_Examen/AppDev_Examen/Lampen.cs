using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_Examen
{
    //Gemaakt via de "paste special" tool voor Visual Studio 2017 RC verdere informatie terug te vinden in de conclusie van het testrapport
    public class Lampen
        {
            public Lampenn[] Lamp { get; set; }
        }

    public class Lampenn
        {
            public int teeltbed { get; set; }
            public int waarde { get; set; }
            public int hoog { get; set; }
            public int laag { get; set; }
        }
}
