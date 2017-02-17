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
        public int Racetrack;
        public Image imJunkrat = null;
        public Random Random;
        public DispatcherTimer Timer = null;
        public int Number;

        public bool Move()
        {

            //Make a random between 1 and 5. This will be the steps Junkrat will take
            int move = Random.Next(3, 8);

            //2. Update the position of my PictureBox on the form
            Vector vector = VisualTreeHelper.GetOffset(imJunkrat);
            Point Punt = new Point(vector.X, vector.Y);
            Punt.X += move;
            Canvas.SetLeft(imJunkrat, Punt.X);


            //3. Return true if I won the race
            if (Punt.X >= Racetrack - 25)
            {
                MessageBox.Show("One lucky Junkrat got hooked on a feeling.", "Aaaand the winner is: Junkrat " + Number + "!");
                Timer.Stop();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
