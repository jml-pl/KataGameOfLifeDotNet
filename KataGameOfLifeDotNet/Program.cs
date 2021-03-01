using System;
using System.IO;

namespace GameOfLife
{
    public class Program
    {
        static int Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a path to file with boards.");
                return 1;
            }

            string boardFile = File.ReadAllText(args[0]);

            string[] boardsLines = boardFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] newBoardLines = Tick(boardsLines);

            PrintBoard(newBoardLines);
            return 0;
        }

        public static void PrintBoard(string[] boardLines)
        {
            foreach (var myString in boardLines)
            {
                Console.WriteLine(myString);
            }
        }

        public static char Life(char state, int livingNeighbours)
        {
            //Console.WriteLine(state + livingNeighbours.ToString());
            if (state.Equals('*'))
            {
                if (livingNeighbours < 2 || livingNeighbours > 3)
                    return '.';
            }
            else
            {
                if (livingNeighbours == 3)
                    return '*';
            }
            return state;
        }

        public static string[] Tick(string[] boardLines)
        {
            string[] newboardLines = new string[boardLines.GetLength(0)];

            newboardLines[0] = boardLines[0];

            for (int i = 1; i < boardLines.GetLength(0); i++)
            {
                var sb = new System.Text.StringBuilder();
                for (int j = 0; j < boardLines[i].Length; j++)
                {
                    int livingNeighbours = 0;
                    for (int iNeighbour = i - 1; iNeighbour <= i + 1; iNeighbour++)
                    {
                        for (int jNeighbour = j - 1; jNeighbour <= j + 1; jNeighbour++)
                        {
                            if (iNeighbour >= 1 && iNeighbour < boardLines.GetLength(0) && jNeighbour >= 0 && jNeighbour < boardLines[i].Length && (iNeighbour != i || jNeighbour != j))
                            {
                                if (boardLines[iNeighbour][jNeighbour] == '*')
                                {
                                    livingNeighbours++;
                                }
                            }

                        }
                    }
                    sb.Append(Life(boardLines[i][j], livingNeighbours));
                }
                newboardLines[i] = sb.ToString();
            }
            return newboardLines;
        }
       
    }






}
