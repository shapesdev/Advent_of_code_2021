using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_of_code_2021.Tasks
{
    abstract class Day : IDay
    {
        protected int puzzleOneResult, puzzleTwoResult;

        public virtual void PrintResults(int dayNr) {
            Console.WriteLine($"DAY {dayNr} RESULTS");
            Console.WriteLine($"Puzzle 1: {puzzleOneResult} && Puzzle 2: {puzzleTwoResult} \n");
        }

        /// <summary>
        /// This function calls ReadInputFromFile and then both SolvePuzzle methods
        /// </summary>
        public virtual void Init() {
            ReadInputFromFile();
            SolveFirstPuzzle();
            SolveSecondPuzzle();
        }

        public abstract void SolveFirstPuzzle();
        public abstract void SolveSecondPuzzle();
        public abstract void ReadInputFromFile();
    }
}
