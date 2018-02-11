using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    class Tetris
    {
        public List<Figure> Figures { get; private set; }
        public FigureCreator Creator { get; set; }
        public Tetris()
        {
            Figures = new List<Figure>();
            Creator = null;
        }
        public Tetris(FigureCreator creator)
        {
            Figures = new List<Figure>();
            Creator = creator;
        }
        public void AddFigure(byte R, byte G, byte B)
        {
            if (Creator == null) throw new ArgumentException("Creator can not be null or empty!");
            Figures.Add(Creator.GetFigure(R, G, B));
        }

        public void AddFigure(byte[] color)
        {
            if (color.Length < 3) throw new ArgumentException("Incorrect color input");
            Figures.Add(Creator.GetFigure(color[0], color[1], color[2]));
        }

        public void PrintAllFigures()
        {
            foreach (var fig in Figures)
            {
                Console.WriteLine(fig + Environment.NewLine);
            }
        }
    }
}
