using Microsoft.VisualBasic.Logging;
using System.Reflection;

namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{
    public Dog[] DogArray = new Dog[4];
    public Guy[] GuyArray = new Guy[3];
    public Random Randomize = new Random();
    public int Chosen = 1;
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
        GuyArray[0] = new Guy("Joe", 50, rb_Guy1, lb_guy1BetLabel);
        GuyArray[1] = new Guy("Bob", 75, rb_Guy2, lb_guy2BetLabel);
        GuyArray[2] = new Guy("Al", 45, rb_Guy3, lb_guy3BetLabel);
        for (int i = 0; i < GuyArray.Length; i++)
        {
            GuyArray[i].UpdateLabels();
        }
    }
    private void bt_race_Click(object sender, EventArgs e)
    {
        bool iedereenGewed = true;
        for (int i = 0; i < GuyArray.Length; i++)
        {
            if (GuyArray[i].HasChosen == false)
            {
                iedereenGewed = false;
            }
        }
        if (iedereenGewed == true && CanChange == true)
        {
            CanChange = false;
            t_raceTimer.Start();
        }
        else
        {
            MessageBox.Show("Nog niet iedereen heeft gewed!!!");
        }
    }

    private void bt_bet_Click(object sender, EventArgs e)
    {
        if (CanChange == true)
        {
            int moneybet = (int)num_dogNumber.Value;
            int chosendog = (int)numericUpDown1.Value;
            if (GuyArray[Chosen - 1].PlaceBet(moneybet, chosendog))
            {
                GuyArray[Chosen - 1].UpdateLabels();
            }
            else
            {
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
        for (int i = 0; i < GuyArray.Length; i++)
        {
            GuyArray[i].Collect(Winner);
            GuyArray[i].UpdateLabels();
        }
        for (int i = 0; i < DogArray.Length; i++)
        {
            DogArray[i].TakeStartingPosition();
        }
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
