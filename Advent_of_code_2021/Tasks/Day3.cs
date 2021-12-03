using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_code_2021.Tasks
{
    class Day3 : Day
    {
        private List<string> binaryValues = new List<string>();

        public Day3() {
            Init();
        }

        public override void SolveFirstPuzzle() {
            string gammaRate = string.Empty;
            string epsilonRate = string.Empty;
            for (int i = 0; i < binaryValues[0].Length; i++) {
                int zeroCount = 0;
                int oneCount = 0;
                for (int j = 0; j < binaryValues.Count; j++) {
                    if(binaryValues[j][i] == '1') {
                        oneCount++;
                    }
                    else if(binaryValues[j][i] == '0') {
                        zeroCount++;
                    }
                }
                if(zeroCount > oneCount) {
                    gammaRate += '0';
                    epsilonRate += '1';
                }
                else {
                    gammaRate += '1';
                    epsilonRate += '0';
                }
            }
            puzzleOneResult = Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
        }

        public override void SolveSecondPuzzle() {
            List<string> oxygenList = new List<string>(binaryValues);
            List<string> scrubberList = new List<string>(binaryValues);

            while (oxygenList.Count != 1) {
                for (int i = 0; i < oxygenList[0].Length; i++) {
                    List<string> zeroBased = new List<string>();
                    List<string> oneBased = new List<string>();
                    for (int j = 0; j < oxygenList.Count; j++) {
                        if (oxygenList[j][i] == '1') {
                            oneBased.Add(oxygenList[j]);
                        }
                        else if (oxygenList[j][i] == '0') {
                            zeroBased.Add(oxygenList[j]);
                        }
                    }
                    if (oneBased.Count >= zeroBased.Count) {
                        oxygenList = new List<string>(oneBased);
                    }
                    else {
                        oxygenList = new List<string>(zeroBased);
                    }
                }
            }

            int index = 0;

            while (scrubberList.Count != 1) {
                var zeroSum = 0;
                var oneSum = 0;
                for (int i = 0; i < scrubberList.Count; i++) {
                    if (scrubberList[i][index].ToString().Equals("1")) {
                        oneSum++;
                    }
                    else {
                        zeroSum++;
                    }
                }

                if (oneSum > zeroSum) {
                    scrubberList = scrubberList.Where(x => x[index].ToString().Equals("0")).ToList();
                }
                if (oneSum == zeroSum) {
                    scrubberList = scrubberList.Where(x => x[index].ToString().Equals("0")).ToList();
                }
                if (oneSum < zeroSum) {
                    scrubberList = scrubberList.Where(x => x[index].ToString().Equals("1")).ToList();
                }
                index++;
            }
            puzzleTwoResult = Convert.ToInt32(oxygenList[0], 2) * Convert.ToInt32(scrubberList[0], 2);
        }

        public override void ReadInputFromFile() {
            string[] numberArr = File.ReadAllLines("Files/day3.txt");
            foreach (var number in numberArr) {
                binaryValues.Add(number);
            }
        }
    }
}
