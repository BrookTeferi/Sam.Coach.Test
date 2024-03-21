using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.Coach
{
    public class LongestRisingSequenceFinder : ILongestRisingSequenceFinder
    {
        public Task<IEnumerable<int>> Find(IEnumerable<int> numbers) => Task.Run(() =>
        {
            IEnumerable<int> result = null;

            // TODO: return the longest raising sequence in the collection provided, i.e.
            // when numbers = [4, 6, -3, 3, 7, 9] then expected result is [-3, 3, 7, 9]
            // when numbers = [9, 6, 4, 5, 2, 0] then expected result is [4, 5]

            if (!numbers.Any())
                return Enumerable.Empty<int>();

            var numbersList = numbers.ToList();
            var dp = new int[numbersList.Count];
            var prev = new int[numbersList.Count];

            for (int i = 0; i < numbersList.Count; i++)
            {
                dp[i] = 1;
                prev[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (numbersList[i] > numbersList[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }
            }

            int maxIndex = 0;
            for (int k = 1; k < numbersList.Count; k++)
            {
                if (dp[k] > dp[maxIndex])
                    maxIndex = k;
            }

            List<int> sequence = new List<int>();
            int currentIndex = maxIndex;
            while (currentIndex != -1)
            {
                sequence.Add(numbersList[currentIndex]);
                currentIndex = prev[currentIndex];
            }

            sequence.Reverse();
            return sequence;
        });
    }
}
