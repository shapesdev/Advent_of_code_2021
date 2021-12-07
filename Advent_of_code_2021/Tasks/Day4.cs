using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_code_2021.Tasks
{
    class Day4 : Day
    {
        public struct Bingo
        {
            public int number;
            public bool marked;

            public Bingo(int number, bool marked) {
                this.number = number;
                this.marked = marked;
            }
        };

        private List<int> calledNumbers = new List<int>();
        private List<Bingo> bingoNumbers = new List<Bingo>();

        private Stack<int> winners = new Stack<int>();

        public Day4() {
            Init();
        }

        public override void SolveFirstPuzzle() {

            bool win = false;

            for (int i = 0; i < calledNumbers.Count; i++) {
                var called = calledNumbers[i];
                if (!win) {
                    for (int j = 0; j < bingoNumbers.Count; j++) {
                        if (bingoNumbers[j].number == called) {
                            Bingo temp;
                            temp.marked = true;
                            temp.number = called;
                            bingoNumbers[j] = temp;

                            int boardNr = (int)MathF.Ceiling((float)(j + 1) / 25);
                            if (CheckBoard(boardNr)) {
                                win = true;
                                int sum = GetSumOfUnmarked(boardNr);
                                puzzleOneResult = sum * called;
                                Reset();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public override void SolveSecondPuzzle() {
            int lastCalled = 0;
            int lastSum = 0;
            for (int i = 0; i < calledNumbers.Count; i++) {
                var called = calledNumbers[i];
                for (int j = 0; j < bingoNumbers.Count; j++) {
                    if (bingoNumbers[j].number == called) {
                        Bingo temp;
                        temp.marked = true;
                        temp.number = called;
                        bingoNumbers[j] = temp;

                        int boardNr = (int)MathF.Ceiling((float)(j + 1) / 25);
                        if (CheckBoard(boardNr)) {
                            if(!winners.Contains(boardNr)) {
                                winners.Push(boardNr);
                                lastSum = GetSumOfUnmarked(boardNr);
                                lastCalled = called;
                            }
                        }
                    }
                }
            }
            puzzleTwoResult = lastSum * lastCalled;
        }

        private bool CheckBoard(int boardNr) {
            int i = boardNr == 1 ? 0 : boardNr * 25 - 25;
            int firstIter = i;

            for (; i < firstIter + 5; i++) {
                int count = 0;
                for (int j = i; j <= i + 20; j += 5) {
                    if (bingoNumbers[j].marked) {
                        count++;
                    }
                }
                if (count == 5) {
                    return true;
                }
            }

            i = boardNr == 1 ? 0 : boardNr * 25 - 25;

            for (; i < boardNr * 25 - 4; i += 5) {
                int count = 0;
                for (int j = i; j < i + 5; j++) {
                    if (bingoNumbers[j].marked) {
                        count++;
                    }
                }
                if (count == 5) {
                    return true;
                }
            }
            return false;
        }

        private int GetSumOfUnmarked(int boardNr) {
            int i = boardNr == 1 ? 0 : boardNr * 25 - 25;
            int sum = 0;
            for (; i < boardNr * 25; i ++) {
                if (!bingoNumbers[i].marked) {
                    sum += bingoNumbers[i].number;
                }
            }
            return sum;
        }

        private void Reset() {
            for(int i = 0; i < bingoNumbers.Count; i++) {
                int j = i;
                Bingo temp;
                temp.marked = false;
                temp.number = bingoNumbers[j].number;
                bingoNumbers[j] = temp;
            }
        }

        public override void ReadInputFromFile() {
            string input = File.ReadAllText("Files/day4.txt");
            string[] inputArray = input.Split('\n', 2);

            string[] calledArray = inputArray[0].Split(',');
            foreach(var called in calledArray) {
                calledNumbers.Add(Convert.ToInt32(called));
            }

            string[] boardArray = Regex.Split(inputArray[1], @"[^\w]+");
            foreach (var boardVal in boardArray) {
                if (!string.IsNullOrWhiteSpace(boardVal)) {
                    var bingo = new Bingo(Convert.ToInt32(boardVal), false);
                    bingoNumbers.Add(bingo);
                }
            }
        }
    }
}
