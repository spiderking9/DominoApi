using DominoApi.Commands.Dto;

namespace DominoApi.Services
{
    public static class DominoService
    {
        public static List<Domino> GenerateRandomDominoes(int numberOfDominoes, int maxNumber)
        {
            var dominoes = new List<Domino>();
            var random = new Random();

            for (int i = 0; i < numberOfDominoes; i++)
            {
                int left = random.Next(1, maxNumber + 1);
                int right = random.Next(1, maxNumber + 1);
                dominoes.Add(new Domino(left, right));
            }

            return dominoes;
        }

        public static List<Domino>? FindCircularChain(List<Domino> dominoes)
        {
            foreach (var start in dominoes)
            {
                var chain = new List<Domino> { start };
                var remaining = new List<Domino>(dominoes.Where(d => d != start));

                if (TryBuildChain(chain, remaining))
                    return chain;
            }

            return null;
        }

        private static bool TryBuildChain(List<Domino> chain, List<Domino> remaining)
        {
            if (remaining.Count == 0)
                return chain.First().Left == chain.Last().Right;

            foreach (var domino in remaining.ToList())
            {
                if (chain.Last().Right == domino.Left)
                {
                    chain.Add(domino);
                    remaining.Remove(domino);

                    if (TryBuildChain(chain, remaining))
                        return true;

                    chain.RemoveAt(chain.Count - 1);
                    remaining.Add(domino);
                }
                else if (chain.Last().Right == domino.Right)
                {
                    domino.Flip();
                    chain.Add(domino);
                    remaining.Remove(domino);

                    if (TryBuildChain(chain, remaining))
                        return true;

                    chain.RemoveAt(chain.Count - 1);
                    remaining.Add(domino);
                    domino.Flip();
                }
            }

            return false;
        }
    }
}
