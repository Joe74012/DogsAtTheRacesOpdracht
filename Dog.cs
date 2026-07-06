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
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;    
        public Random Randomizer;

        public bool Run()
        {
            int Number = Randomizer.Next(0, 4);
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
