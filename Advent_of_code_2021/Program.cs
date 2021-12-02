using System;
using System.Collections.Generic;
using Advent_of_code_2021.Tasks;

namespace Advent_of_code_2021
{
    class Program
    {
        static void Main(string[] args) {
            List<IDay> days = new List<IDay>() {
                new Day1(),
                new Day2()
            };

            for(int i = 0; i < days.Count; i++) {
                days[i].PrintResults(i+1);
            }

            Console.ReadLine();
        }
    }
}
