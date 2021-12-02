using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_code_2021.Tasks
{
    class Day1 : Day
    {
        private List<int> depthList;

        public Day1() {
            depthList = new List<int>();
            Init();
        }

        public override void SolveFirstPuzzle() {
            for (int i = 1; i < depthList.Count; i++) {
                if (depthList[i] > depthList[i - 1]) {
                    puzzleOneResult++;
                }
            }
        }

        public override void SolveSecondPuzzle() {
            for (int i = 1; i < depthList.Count - 2; i++) {
                int sum1 = depthList[i - 1] + depthList[i] + depthList[i + 1];
                int sum2 = depthList[i] + depthList[i + 1] + depthList[i + 2];
                if (sum2 > sum1) {
                    puzzleTwoResult++;
                }
            }
        }

        public override void ReadInputFromFile() {
            string[] numberArr = File.ReadAllLines("Files/day1.txt");
            foreach (var number in numberArr) {
                int temp;
                if (int.TryParse(number, out temp)) {
                    depthList.Add(temp);
                }
            }
        }
    }
}
