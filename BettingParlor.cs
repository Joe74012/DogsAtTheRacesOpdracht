using Microsoft.VisualBasic.Logging;
using System.Reflection;

namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{
    public Dog[] DogArray = new Dog[4];
    public Guy[] GuyArray = new Guy[3];
    public Random Randomize = new Random();
    public int Gekozen = 1;
    public bool HeeftGekozen1 = false;
    public bool HeeftGekozen2 = false;
    public bool HeeftGekozen3 = false;

    public BettingParlor()
    {
        InitializeComponent();
        DogArray[0] = new Dog()
        {
            MyPictureBox = pb_dog1,
            StartingPosition = pb_dog1.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog1.Width,
            Randomizer = Randomize
        };
        DogArray[1] = new Dog()
        {
            MyPictureBox = pb_dog2,
            StartingPosition = pb_dog2.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog2.Width,
            Randomizer = Randomize
        };
        DogArray[2] = new Dog()
        {
            MyPictureBox = pb_dog3,
            StartingPosition = pb_dog3.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog3.Width,
            Randomizer = Randomize
        };
        DogArray[3] = new Dog()
        {
            MyPictureBox = pb_dog4,
            StartingPosition = pb_dog4.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog4.Width,
            Randomizer = Randomize
        };
        GuyArray[0] = new Guy()
        {
            name = "Joe",
            Cash = 50,
            MyRadioButton = rb_Guy1,
            MyLabel = lb_guy1BetLabel
        };
        GuyArray[1] = new Guy()
        {
            name = "Bob",
            Cash = 75,
            MyRadioButton = rb_Guy2,
            MyLabel = lb_guy2BetLabel
        };
        GuyArray[2] = new Guy()
        {
            name = "Al",
            Cash = 45,
            MyRadioButton = rb_Guy3,
            MyLabel = lb_guy3BetLabel
        };
        GuyArray[0].UpdateLabels();
        GuyArray[1].UpdateLabels();
        GuyArray[2].UpdateLabels();
    }
    private void bt_race_Click(object sender, EventArgs e)
    {
        if (HeeftGekozen1 && HeeftGekozen2 && HeeftGekozen3) {
            t_raceTimer.Start();
        } else
        {
            MessageBox.Show("Nog niet iedereen heeft gewet!!!");
        }
    }

    private void bt_bet_Click(object sender, EventArgs e)
    {
        if (Gekozen == 1)
        {
            int moneybet = (int)num_dogNumber.Value;
            int chosendog = (int)numericUpDown1.Value;
            if (GuyArray[Gekozen - 1].PlaceBet(moneybet, chosendog))
            {
                HeeftGekozen1 = true;

                GuyArray[Gekozen - 1].MyBet = new Bet()
                {
                    Amount = moneybet,
                    Dog = chosendog,
                    Bettor = GuyArray[Gekozen - 1]
                };
                lb_guy1BetLabel.Text = GuyArray[Gekozen - 1].MyBet.GetDescription();
            }
            else
            {
                HeeftGekozen1 = false;
                MessageBox.Show("niet genoeg geld!!!");
            }
        }
        else if (Gekozen == 2) {
            int moneybet = (int)num_dogNumber.Value;
            int chosendog = (int)numericUpDown1.Value;
            if (GuyArray[Gekozen - 1].PlaceBet(moneybet, chosendog))
            {
                HeeftGekozen2 = true;

                GuyArray[Gekozen - 1].MyBet = new Bet()
                {
                    Amount = moneybet,
                    Dog = chosendog,
                    Bettor = GuyArray[Gekozen - 1]
                };
                lb_guy2BetLabel.Text = GuyArray[Gekozen - 1].MyBet.GetDescription();
            }
            else
            {
                HeeftGekozen2 = false;
                MessageBox.Show("niet genoeg geld!!!");
            }
        } else if (Gekozen == 3) {
            int moneybet = (int)num_dogNumber.Value;
            int chosendog = (int)numericUpDown1.Value;
            if (GuyArray[Gekozen - 1].PlaceBet(moneybet, chosendog))
            {
                HeeftGekozen3 = true;

                GuyArray[Gekozen - 1].MyBet = new Bet()
                {
                    Amount = moneybet,
                    Dog = chosendog,
                    Bettor = GuyArray[Gekozen - 1]
                };
                lb_guy3BetLabel.Text = GuyArray[Gekozen - 1].MyBet.GetDescription();
            }
            else
            {
                HeeftGekozen3 = false;
                MessageBox.Show("niet genoeg geld!!!");
            }
        }
    }


    private void t_raceTimer_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < DogArray.Length; i++)
        {
            if (DogArray[i].Run())
            {
                MessageBox.Show("hond nummer " + (i + 1) + " heeft gewonnen");
                t_raceTimer.Stop();
            }
        }
    }

    public void rb_Guy1_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy1.Checked)
        {
            Gekozen = 1;
            lb_name.Text = GuyArray[0].name;
        }
    }
    public void rb_Guy2_CheckedChanged_1(object sender, EventArgs e)
    {
        if (rb_Guy2.Checked)
        {
            Gekozen = 2;
            lb_name.Text = GuyArray[1].name;
        }
    }
    public void rb_Guy3_CheckedChanged_1(object sender, EventArgs e)
    {
        if (rb_Guy3.Checked)
        {
            Gekozen = 3;
            lb_name.Text = GuyArray[2].name;
        }
    }

    private void num_dogNumber_ValueChanged(object sender, EventArgs e)
    {

    }
}
