using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GreyhoundRace
{
    class Junkrat
    {
        public int StartPosition;
        public int Racetrack; 
        public Canvas Junkrats = null;
        public int Location = 0; 
        public Random Random;

        public bool Move()
        {
            //Make a random between 1 and 5. This will be the steps Junkrat will take
            int move = Random.Next(1, 5); 

            //2. Update the position of my PictureBox on the form
            Point Punt = new Point(Canvas.GetTop(Junkrats), Canvas.GetLeft(Junkrats));
            Punt.X += move;
            Canvas.SetLeft(Junkrats, Punt.X);
            Canvas.SetTop(Junkrats, Punt.Y);


            //3. Return true if I won the race
            if (Punt.X >= Racetrack)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Used to restart the startposition
        public void Reset()
        {
            StartPosition = 0;
        }
    }
}
