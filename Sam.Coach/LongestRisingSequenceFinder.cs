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
            var lengths = new int[numbersList.Count];
            var previousIndices = new int[numbersList.Count];

          
            for (int i = 0; i < numbersList.Count; i++)
            {
                lengths[i] = 1;
                previousIndices[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (numbersList[j] < numbersList[i] && lengths[j] + 1 > lengths[i])
                    {
                        lengths[i] = lengths[j] + 1;
                        previousIndices[i] = j;
                    }
                }
            }

            int maxIndex = 0, maxLength = 0;
            for (int i = 0; i < lengths.Length; i++)
            {
                if (lengths[i] > maxLength)
                {
                    maxLength = lengths[i];
                    maxIndex = i;
                }
            }

        
            if (maxLength == 1)
            {
                return new List<int> { numbersList.Min() };
            }

            var sequence = new List<int>();
            while (maxIndex != -1)
            {
                sequence.Add(numbersList[maxIndex]);
                maxIndex = previousIndices[maxIndex];
            }

            sequence.Reverse();
            return sequence.AsEnumerable();
        });
    }
}