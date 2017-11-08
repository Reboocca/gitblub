using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_Examen
{
    class sproeier
    {
        public int TeeltBed { get; set; }
        public AanUit Stand { get; set; }
        public double Actueel { get; set; }
        public double Hoog { get; set; }
        public double Laag { get; set; }

        public sproeier(int teeltbed, double hoog, double laag, double actueel, AanUit stand)
        {
            TeeltBed = teeltbed;
            Hoog = hoog;
            Laag = laag;
            Actueel = actueel;
            Stand = stand;
        }
    }
}
