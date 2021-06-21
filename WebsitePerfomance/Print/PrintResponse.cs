using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePerfomance.Print
{
    public class PrintResponse
    {
        public void PrintTable(List<PerfomanceResult> resultList)
        {
            var table = new ConsoleTable("N", "Url", "Timing(ms)");

            for (int i = 1; i <= resultList.Count; i++)
            {
                table.AddRow(i, resultList[i - 1].Link, resultList[i - 1].ResponseTime.Milliseconds + " ms");
            }

            table.Options.EnableCount = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            table.Write();
        }
    }
}
