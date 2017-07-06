<Query Kind="Program" />

void Main()
{
	Program.Main(null);
}

// Define other methods and classes here
class Program
{
    public static void Main(string[] args)
    {
        Random rand = new Random();

        int noSwitchWins = RunGames(rand, false, 10000);
        int switchWins = RunGames(rand, true, 10000);

        Console.WriteLine(string.Format("If you don't switch, you will win {0} out of 1000 games.", noSwitchWins));
        Console.WriteLine(string.Format("If you switch, you will win {0} out of 1000 games.", switchWins));

        Console.ReadLine();
    }

    static int RunGames(Random rand, bool doSwitch, int numberOfRuns)
    {
        int counter = 0;

        for (int i = 0; i < numberOfRuns; i++)
        {
            bool isWin = RunGame(rand, doSwitch);
            if (isWin)
                counter++;
        }

        return counter;
    }

    static bool RunGame(Random rand, bool doSwitch)
    {
        int prize = rand.Next(0, 2);
        int selection = rand.Next(0, 2);

        // available choices
        List<Choice> choices = new List<Choice> { new Choice(), new Choice(), new Choice() };
        choices[prize].IsPrize = true;
        choices[selection].IsSelected = true;
        Choice selectedChoice = choices[selection];
        int randomlyDisplayedDoor = rand.Next(0, 1);

        // one of the choices are displayed
        var choicesToDisplay = choices.Where(x => !x.IsSelected && !x.IsPrize);
        var displayedChoice = choicesToDisplay.ElementAt(choicesToDisplay.Count() == 1 ? 0 : randomlyDisplayedDoor);
        choices.Remove(displayedChoice);

        // would you like to switch?
        if (doSwitch)
        {
            Choice initialChoice = choices.Where(x => x.IsSelected).FirstOrDefault();
            selectedChoice = choices.Where(x => !x.IsSelected).FirstOrDefault();
            selectedChoice.IsSelected = true;
        }

        return selectedChoice.IsPrize;
    }
}

class Choice
{
    public bool IsPrize = false;
    public bool IsSelected = false;
}