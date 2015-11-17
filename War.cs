using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.play();
            Player winner = g.getWinner();
            if (winner == null)
                Console.WriteLine("Tie game.");
            else
                Console.WriteLine("\nWinner = " + winner.getName());
            Console.ReadKey();
        }
    }
}
