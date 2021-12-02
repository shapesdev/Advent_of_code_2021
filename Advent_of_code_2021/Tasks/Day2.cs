using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_code_2021.Tasks
{
    class Day2 : Day
    {
        enum Command
        {
            forward, down, up
        };

        int depth = 0;
        int horizontal = 0;

        private List<Tuple<Command, int>> commands = new List<Tuple<Command, int>>();

        public Day2() {
            Init();
        }

        public override void SolveFirstPuzzle() {
            foreach (var cmd in commands) {
                if(cmd.Item1 == Command.forward) {
                    horizontal += cmd.Item2;
                }
                else if(cmd.Item1 == Command.up) {
                    depth -= cmd.Item2;
                }
                else if(cmd.Item1 == Command.down) {
                    depth += cmd.Item2;
                }
            }
            puzzleOneResult = depth * horizontal;
        }

        public override void SolveSecondPuzzle() {
            int aim = 0;
            depth = 0;
            foreach (var cmd in commands) {
                if (cmd.Item1 == Command.forward) {
                    depth += aim * cmd.Item2;
                }
                else if (cmd.Item1 == Command.up) {
                    aim -= cmd.Item2;
                }
                else if (cmd.Item1 == Command.down) {
                    aim += cmd.Item2;
                }
            }
            puzzleTwoResult = depth * horizontal;
        }

        public override void ReadInputFromFile() {
            string[] text = File.ReadAllLines("Files/day2.txt");
            foreach (var line in text) {
                int value;
                Command cmd;
                string[] temp = line.Split(' ');

                if(Enum.TryParse(temp[0], out cmd)) {
                    if(int.TryParse(temp[1], out value)) {
                        commands.Add(Tuple.Create(cmd, value));
                    }
                }
            }
        }
    }
}
