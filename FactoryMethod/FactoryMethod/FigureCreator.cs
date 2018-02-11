using System;
namespace FactoryMethod
{
    abstract class FigureCreator
    {
        abstract public Figure GetFigure(byte R, byte G, byte B);
    }

    class ZFigureCreator : FigureCreator
    {
        public override Figure GetFigure(byte R, byte G, byte B)
        {
            return new Block_Z(R, G, B);
        }
    }

    class SFigureCreator : FigureCreator
    {
        public override Figure GetFigure(byte R, byte G, byte B)
        {
            return new Block_S(R, G, B);
        }
    }

    class IFigureCreator : FigureCreator
    {
        public override Figure GetFigure(byte R, byte G, byte B)
        {
            return new Block_I(R, G, B);
        }
    }

    class TFigureCreator : FigureCreator
    {
        public override Figure GetFigure(byte R, byte G, byte B)
        {
            return new Block_T(R, G, B);
        }
    }

    class JFigureCreator : FigureCreator
    {
        public override Figure GetFigure(byte R, byte G, byte B)
        {
            return new Block_J(R, G, B);
        }
    }

    class LFigureCreator : FigureCreator
    {
        public override Figure GetFigure(byte R, byte G, byte B)
        {
            return new Block_L(R, G, B);
        }
    }
}
