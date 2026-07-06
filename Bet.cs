using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAtTheRaces
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount == 0)
            {
                return Bettor.name + " hasn't placed a bet";
            } else
            {
                return Bettor.name + " bets " + Amount + " on dog #" + Dog;
            }
        }
        public int PayOut(int Winner)
        {
            return Winner;
        }
    }
}
