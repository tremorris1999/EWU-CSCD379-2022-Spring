namespace Wordle.Api.Services
{
    public class Score
    {
        public string Name { get; set; }
        public int NumberGames { get; set; }
        public double AverageGuesses { get; set; }

        public Score(string name, int numberGames, double averageGuesses)
        {
            Name = name;
            NumberGames = numberGames;
            AverageGuesses = averageGuesses;
        }
    }
}
