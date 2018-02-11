using System;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static byte[] GetRandomColor(Random rnd)
        {
            return new byte[] { (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255) };
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            var tetris = new Tetris();

            tetris.Creator = new IFigureCreator();
            tetris.AddFigure(1, 23, 4);

            tetris.Creator = new JFigureCreator();
            tetris.AddFigure(GetRandomColor(rnd));

            tetris.Creator = new LFigureCreator();
            tetris.AddFigure(GetRandomColor(rnd));

            tetris.Creator = new SFigureCreator();
            tetris.AddFigure(GetRandomColor(rnd));

            tetris.Creator = new ZFigureCreator();
            tetris.AddFigure(GetRandomColor(rnd));

            tetris.Creator = new TFigureCreator();
            tetris.AddFigure(GetRandomColor(rnd));

            tetris.PrintAllFigures();
        }
    }
}
