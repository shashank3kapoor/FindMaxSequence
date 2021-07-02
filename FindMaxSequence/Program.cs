using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMaxSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberList = new List<int> {
                1,2,-1,-5,-4, 5, 6, -1, 7, 8, -1, -5, -4, -3, -2, 5
            };

            var maxSum = 0;
            var runningSum = 0;
            var startIndex = 0;
            var sequenceList = new List<SequenceSumInfo>();
            for (int i = 0; i < numberList.Count; i++)
            {
                if (maxSum < runningSum)
                {
                    maxSum = runningSum;
                    sequenceList.Add(new SequenceSumInfo
                    {
                        StartIndex = startIndex,
                        EndIndex = i,
                        SumOfSequence = runningSum
                    });
                }

                if (runningSum <= 0)
                {
                    startIndex = i;
                    runningSum = 0;
                }

                runningSum += numberList[i];
            }

            var maxSequenceInfo = sequenceList.MaxBy(s => s.SumOfSequence);

            Console.WriteLine("\n Max=> StartIndex: " + maxSequenceInfo.StartIndex + " \tEndIndex:" + maxSequenceInfo.EndIndex + " \tSum:" + maxSequenceInfo.SumOfSequence);

            var maxSequenceValues = string.Join(",", numberList
                .Skip(maxSequenceInfo.StartIndex)
                .Take(maxSequenceInfo.EndIndex - maxSequenceInfo.StartIndex)
                .Select(x => x)
                .ToList());

            Console.WriteLine("\n MaxSequenceValues: " + maxSequenceValues);
        }

        class SequenceSumInfo
        {
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
            public int SumOfSequence { get; set; }
        }
    }
}
