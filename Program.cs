class GuessingGame 
{
    public string Name { get; set; }
    public int ID { get; set; }
    private static int _turn;
    private static int _hiddenNumber;
    private static List<GuessingGame> _players;

    static GuessingGame()
    {
        _players = new List<GuessingGame>();
        _turn = 0;
        _hiddenNumber = (new Random()).Next(1, 100);

    }
    public GuessingGame(string name)
    {
        Name = name;
        ID = 100 + _players.Count;
    }

    public static void AddPlayer(string name)
    {
        _players.Add(new GuessingGame(name));
    }
    public static bool MatchingGuess(int number)
    {
        if(number == _hiddenNumber)
        {
            return true;
        }
        else if (number > _hiddenNumber) 
        {
            Console.WriteLine("Guess Lower....");
            return false;
        }
        else {
            Console.WriteLine("Guess Higher....");
            return false; }
    }
    public static bool Play()
    {
        Console.WriteLine();
        Console.WriteLine($"Please Make a Guess, {_players[_turn]}");
      int  number = int.Parse(Console.ReadLine());
        if (MatchingGuess(number))
        {
            Console.WriteLine($"Congratulations {_players[_turn]}You guessed correctly.");
            return false;
        }
        else
        {
            _turn = (_turn + 1) % _players.Count;
            return true;
        }
    }

    public override string ToString()
    {
        return $"Player: {Name}, ID: {ID} \n";
    }
}

class Program
{
    static void Main(string[] args)
    { 
        GuessingGame.AddPlayer("Chidi");
        GuessingGame.AddPlayer("Nonso");
        GuessingGame.AddPlayer("Ife");
        GuessingGame.AddPlayer("Chisom");
        while (GuessingGame.Play()) ;

    }
}




