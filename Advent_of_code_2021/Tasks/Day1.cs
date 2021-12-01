using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Advent_of_code_2021.Tasks
{
    class Day1 : IDay
    {
        private List<int> depthList;
        private int puzzleOneResult, puzzleTwoResult;

        public Day1() {
            depthList = new List<int>();
            ReadInputFromFile();
            SolveFirstPuzzle();
            SolveSecondPuzzle();
        }

        public void PrintResults() {
            Console.WriteLine("DAY 1 RESULTS");
            Console.WriteLine($"Puzzle 1: {puzzleOneResult} && Puzzle 2: {puzzleTwoResult} \n");
        }

        public void SolveFirstPuzzle() {
            for (int i = 1; i < depthList.Count; i++) {
                if (depthList[i] > depthList[i - 1]) {
                    puzzleOneResult++;
                }
            }
        }

        public void SolveSecondPuzzle() {
            for (int i = 1; i < depthList.Count - 2; i++) {
                int sum1 = depthList[i - 1] + depthList[i] + depthList[i + 1];
                int sum2 = depthList[i] + depthList[i + 1] + depthList[i + 2];
                if (sum2 > sum1) {
                    puzzleTwoResult++;
                }
            }
        }

        private void ReadInputFromFile() {
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
