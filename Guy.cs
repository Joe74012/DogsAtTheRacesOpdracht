using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
            MyRadioButton.Text = name + " has " + Cash + " bucks";
            MyLabel.Text = MyBet.GetDescription();
        }
        public void ClearBet()
        {
            MyBet.Dog = 0;
            MyBet.Amount = 0;
        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            Cash += MyBet.Amount;
            if (Cash >= BetAmount) {
                Cash -= BetAmount;
                MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
                UpdateLabels();
                return true;
            } else
            {
                Cash -= MyBet.Amount;
                return false;
            }
        }
        public void Collect(int Winner)
        {
            Cash += MyBet.Amount;
            Cash += MyBet.PayOut(Winner);
            ClearBet();
            UpdateLabels();
        }
    }
}
