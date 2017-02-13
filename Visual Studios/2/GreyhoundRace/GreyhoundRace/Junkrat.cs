using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace GreyhoundRace
{
    class Junkrat
    {
        public int StartPosition;
        public int Racetrack; 
        public Canvas Junkrats = null;
        public Image imJunkrat = null;
        public int Location = 0; 
        public Random Random;
        public DispatcherTimer Timer = null;

        public bool Move()
        {

            //Make a random between 1 and 5. This will be the steps Junkrat will take
            int move = Random.Next(1, 5);

            //2. Update the position of my PictureBox on the form
            Vector vector = VisualTreeHelper.GetOffset(imJunkrat);
            Point Punt = new Point(vector.X, vector.Y);
            Punt.X += move;
            Canvas.SetLeft(imJunkrat, Punt.X);


            //3. Return true if I won the race
            if (Punt.X >= Racetrack - 25)
            {
                MessageBox.Show("STOP THE RACE OR JUNKRAT WILL BE LOST FOREVER");
                Timer.Stop();
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
