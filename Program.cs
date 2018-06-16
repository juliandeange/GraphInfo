using System;
using System.Linq;
using System.IO;

namespace GraphInfo {
    class MainClass {
        public static void Main(string[] args) {
            StreamReader reader = new StreamReader("/Users/juliandeangelis/Downloads/ass4-graphs.txt");

            for (int q = 0; q < 6; q++) {
                 
                int edgeCount = 0;
                int pendantCount = 0;
                int maxDegree = 0;
                int currentMaxDegree = 0;
                int oddVertexCount = 0;

                string line;
                line = reader.ReadLine();
                int n = Convert.ToInt32(line);
                int[,] matrix = new int[n, n];

            string[] row;
            int rownum = 0;
            for (int g = 0; g < n; g++) {
                line = reader.ReadLine();
                row = line.Split(' ');
                for (int t = 0; t < n; t++)
                    matrix[rownum, t] = Convert.ToInt32(row[t]);
                rownum++;
            }
                int singleOne = 0;
                for (int x = 0; x < n; x++) {
                    for (int y = 0; y < n; y++) {
                        if (matrix[x, y] == 1) {
                            edgeCount++;
                            singleOne++;
                            currentMaxDegree = singleOne;
                            if (currentMaxDegree > maxDegree)
                                maxDegree = currentMaxDegree;
                        }
                    }
                    if (singleOne == 1)
                        pendantCount++;
                    if (singleOne % 2 != 0)
                        oddVertexCount++;
                    singleOne = 0;

                }
                Console.Write("Graph  {0}:     ", q + 1);
                Console.Write("{0} edges", edgeCount / 2);
                Console.Write(", {0} pendants", pendantCount);
                Console.Write(", {0} largest degree", maxDegree);
                if (oddVertexCount == 0 || oddVertexCount == 2)
                    Console.Write(", HAS Euler path");
                else
                    Console.Write(", NO Euler path");
                Console.WriteLine();
            }
        }
    }
}
