using Microsoft.VisualBasic.Logging;
using System.Reflection;

namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{
    public Dog[] DogArray = new Dog[4];
    public Guy[] GuyArray = new Guy[3];
    public Random Randomize = new Random();
    public int Chosen = 1;
    public bool HasChosen1 = false;
    public bool HasChosen2 = false;
    public bool HasChosen3 = false;
    public bool CanChange = true;

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
            MyBet = new Bet()
            {
                Amount = 0,
                Dog = 0,
            },
            MyLabel = lb_guy1BetLabel
        };
        GuyArray[0].MyBet.Bettor = GuyArray[0];
        GuyArray[1] = new Guy()
        {
            name = "Bob",
            Cash = 75,
            MyRadioButton = rb_Guy2,
            MyBet = new Bet()
            {
                Amount = 0,
                Dog = 0,
            },
            MyLabel = lb_guy2BetLabel
        };
        GuyArray[1].MyBet.Bettor = GuyArray[1];
        GuyArray[2] = new Guy()
        {
            name = "Al",
            Cash = 45,
            MyRadioButton = rb_Guy3,
            MyBet = new Bet()
            {
                Amount = 0,
                Dog = 0,
            },
            MyLabel = lb_guy3BetLabel
        };
        GuyArray[2].MyBet.Bettor = GuyArray[2];
        GuyArray[0].UpdateLabels();
        GuyArray[1].UpdateLabels();
        GuyArray[2].UpdateLabels();
        lb_guy1BetLabel.Text = GuyArray[0].MyBet.GetDescription();
        lb_guy2BetLabel.Text =  GuyArray[1].MyBet.GetDescription();
        lb_guy3BetLabel.Text =  GuyArray[2].MyBet.GetDescription();
    }
    private void bt_race_Click(object sender, EventArgs e)
    {
        if (HasChosen1 && HasChosen2 && HasChosen3 && CanChange == true) {
            CanChange = false;
            t_raceTimer.Start();
        } else
        {
            MessageBox.Show("Nog niet iedereen heeft gewet!!!");
        }
    }

    private void bt_bet_Click(object sender, EventArgs e)
    {
        if (CanChange == true)
        {
            if (Chosen == 1)
            {
                int moneybet = (int)num_dogNumber.Value;
                int chosendog = (int)numericUpDown1.Value;
                if (GuyArray[Chosen - 1].PlaceBet(moneybet, chosendog))
                {
                    HasChosen1 = true;

                    GuyArray[Chosen - 1].MyBet = new Bet()
                    {
                        Amount = moneybet,
                        Dog = chosendog,
                        Bettor = GuyArray[Chosen - 1]
                    };
                    lb_guy1BetLabel.Text = GuyArray[Chosen - 1].MyBet.GetDescription();
                }
                else
                {
                    HasChosen1 = false;
                    MessageBox.Show("niet genoeg geld!!!");
                }
            }
            else if (Chosen == 2)
            {
                int moneybet = (int)num_dogNumber.Value;
                int chosendog = (int)numericUpDown1.Value;
                if (GuyArray[Chosen - 1].PlaceBet(moneybet, chosendog))
                {
                    HasChosen2 = true;

                    GuyArray[Chosen - 1].MyBet = new Bet()
                    {
                        Amount = moneybet,
                        Dog = chosendog,
                        Bettor = GuyArray[Chosen - 1]
                    };
                    lb_guy2BetLabel.Text = GuyArray[Chosen - 1].MyBet.GetDescription();
                }
                else
                {
                    HasChosen2 = false;
                    MessageBox.Show("niet genoeg geld!!!");
                }
            }
            else if (Chosen == 3)
            {
                int moneybet = (int)num_dogNumber.Value;
                int chosendog = (int)numericUpDown1.Value;
                if (GuyArray[Chosen - 1].PlaceBet(moneybet, chosendog))
                {
                    HasChosen3 = true;

                    GuyArray[Chosen - 1].MyBet = new Bet()
                    {
                        Amount = moneybet,
                        Dog = chosendog,
                        Bettor = GuyArray[Chosen - 1]
                    };
                    lb_guy3BetLabel.Text = GuyArray[Chosen - 1].MyBet.GetDescription();
                }
                else
                {
                    HasChosen3 = false;
                    MessageBox.Show("niet genoeg geld!!!");
                }
            }
        }
    }


    private void t_raceTimer_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < DogArray.Length; i++)
        {
            if (DogArray[i].Run())
            {
                t_raceTimer.Stop();
                MessageBox.Show("hond " + (i + 1) + " heeft gewonnen!!");
                Reset(i + 1);
                break;
            }
        }
    }
    public void Reset(int Winner)
    {
        CanChange = true;
        HasChosen1 = false;
        HasChosen2 = false;
        HasChosen3 = false;
        for (int i = 0; i < GuyArray.Length; i++)
        {
            GuyArray[i].Collect(Winner);
            GuyArray[i].UpdateLabels();
        }
        for (int i = 0; i < DogArray.Length; i++)
        {
            DogArray[i].TakeStartingPosition();
        }
        lb_guy1BetLabel.Text = GuyArray[0].MyBet.GetDescription();
        lb_guy2BetLabel.Text = GuyArray[1].MyBet.GetDescription();
        lb_guy3BetLabel.Text = GuyArray[2].MyBet.GetDescription();
    }

    public void rb_Guy1_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy1.Checked)
        {
            Chosen = 1;
            lb_name.Text = GuyArray[0].name;
        }
    }
    public void rb_Guy2_CheckedChanged_1(object sender, EventArgs e)
    {
        if (rb_Guy2.Checked)
        {
            Chosen = 2;
            lb_name.Text = GuyArray[1].name;
        }
    }
    public void rb_Guy3_CheckedChanged_1(object sender, EventArgs e)
    {
        if (rb_Guy3.Checked)
        {
            Chosen = 3;
            lb_name.Text = GuyArray[2].name;
        }
    }
}
