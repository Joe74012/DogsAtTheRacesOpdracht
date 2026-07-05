using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsAtTheRaces
{
    public class Guy
    {
        public string name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;
        public void UpdateLabels()
        {
            MyLabel.Text = name + " bets " + MyBet.Amount + "on dog #" + MyBet.Dog;
            MyRadioButton.Text = name + " has " + Cash + " bucks";
        }
        public void ClearBet()
        {
            MyBet.Amount = 0;
        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            BetAmount = MyBet.Amount;
            if (Cash >= BetAmount) {
                return true;
            } else
            {
                return false;
            }
        }
        public void Collect(int Winner)
        {

        }
    }
}
