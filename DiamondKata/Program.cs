using System;

namespace DiamondKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadKey().KeyChar;

            try
            {
                var diamond = new Diamond();
                Console.WriteLine();
                Console.WriteLine(diamond.Create(input));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
