using Microsoft.VisualBasic.Logging;

namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{
    public Dog[] DogArray = new Dog[4];
    public Guy[] GuyArray = new Guy[3];


    public BettingParlor()
    {
        InitializeComponent();
        DogArray[0] = new Dog()
        {
            MyPictureBox = pb_dog1,
            StartingPosition = pb_dog1.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog1.Width,
            Randomizer = new Random()
        };
        DogArray[1] = new Dog()
        {
            MyPictureBox = pb_dog2,
            StartingPosition = pb_dog2.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog2.Width,
            Randomizer = new Random()
        };
        DogArray[2] = new Dog()
        {
            MyPictureBox = pb_dog3,
            StartingPosition = pb_dog3.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog3.Width,
            Randomizer = new Random()
        };
        DogArray[3] = new Dog()
        {
            MyPictureBox = pb_dog4,
            StartingPosition = pb_dog4.Left,
            RacetrackLength = pb_raceTrack.Width - pb_dog4.Width,
            Randomizer = new Random()
        };
        GuyArray[0] = new Guy()
        {
            name = "Joe",
            MyBet = new Bet()
            {
                Amount = 7,
                Dog = 3,
                Bettor = GuyArray[0]
            },
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
        GuyArray[1].PlaceBet(7, 3);
        GuyArray[0].UpdateLabels();
        GuyArray[1].UpdateLabels();
        GuyArray[2].UpdateLabels();
        timer1_Tick();
    }
    private void timer1_Tick()
    {
        for (int i = 0; i < DogArray.Length;)
        {
            if (DogArray[i].Run())
            {
                label2.Text = DogArray[i] + " Heeft gewonnen";
            }
            else
            {
                i++;
            }
        }
    }

    private void bt_race_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void bt_bet_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }


    private void t_raceTimer_Tick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
