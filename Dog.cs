using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsAtTheRaces
{
    public class Dog
    {
        private int StartingPosition;
        private int RacetrackLength;
        private PictureBox MyPictureBox;
        private int Location = 0;
        private Random Randomizer;

        public Dog(PictureBox dogPictureBox, int raceTrackWidth, Random dogRandomizer)
        {
            MyPictureBox = dogPictureBox;
            StartingPosition = dogPictureBox.Left;
            RacetrackLength = raceTrackWidth - dogPictureBox.Width;
            Randomizer = dogRandomizer;
        }

        public bool Run()
        {
            int Number = Randomizer.Next(0, 12);
            Location += Number;
            MyPictureBox.Left = StartingPosition + Location;
            if (Location >= RacetrackLength)
            {
                return true;
            } 
            else 
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
