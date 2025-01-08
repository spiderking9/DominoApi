namespace DominoApi.Commands.Dto
{
    public class DominoesSeeder
    {
        public DominoesSeeder(int numberOfDominoes, int maxNumber)
        {
            NumberOfDominoes = numberOfDominoes;
            MaxNumber = maxNumber;
        }

        public int NumberOfDominoes { get; set; }
        public int MaxNumber { get; set; }
    }
}
