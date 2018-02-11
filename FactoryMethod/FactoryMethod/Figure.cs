using System.Text;

namespace FactoryMethod
{
    abstract class Figure
    { 
        public string Type { get; protected set; }
        public byte[,] FigGeometry { get; protected set; }
        public byte[] Color { get; protected set; }
        public Figure(byte R, byte G, byte B) { Color = new byte[3]; SetColor(R, G, B); }
        public void SetColor(byte R, byte G, byte B)
        {
            Color[0] = R;
            Color[1] = G;
            Color[2] = B;
        }
        public override string ToString()
        {
            var output = new StringBuilder($"Type: {Type}\nColor: R:{Color[0]}, G:{Color[1]}, B:{Color[2]}\n", 200);
            for (int i = 0; i < FigGeometry.GetLength(0); i++)
            {
                for (int j = 0; j < FigGeometry.GetLength(1); j++)
                {
                    output.Append(FigGeometry[i,j]);
                }
                if (i == FigGeometry.GetLength(0) - 1)
                    break;
                output.Append('\n');
            }
            return output.ToString();
        }
    }

    class Block_I : Figure
    {
        public Block_I(byte R, byte G, byte B) : base(R, G, B)
        {
            Type = "I-Block";
            FigGeometry = new byte[4, 4] { { 0, 0, 1, 0 },
                                           { 0, 0, 1, 0 },
                                           { 0, 0, 1, 0 },
                                           { 0, 0, 1, 0 } };
        }
    }

    class Block_S : Figure
    {
        public Block_S(byte R, byte G, byte B) : base(R, G, B)
        {
            Type = "S-Block";
            FigGeometry = new byte[4, 4] { { 0, 0, 1, 1 },
                                           { 0, 1, 1, 0 },
                                           { 1, 1, 0, 0 },
                                           { 0, 0, 0, 0 } };

        }
    }

    class Block_Z : Figure
    {
        public Block_Z(byte R, byte G, byte B) : base(R, G, B)
        {
            Type = "Z-Block";
            FigGeometry = new byte[4, 4] { { 1, 1, 0, 0 },
                                           { 0, 1, 1, 0 },
                                           { 0, 0, 1, 1 },
                                           { 0, 0, 0, 0 } };

        }
    }

    class Block_J : Figure
    {
        public Block_J(byte R, byte G, byte B) : base(R, G, B)
        {
            Type = "J-Block";
            FigGeometry = new byte[4, 4] { { 0, 0, 0, 0 },
                                           { 1, 0, 0, 0 },
                                           { 1, 1, 1, 0 },
                                           { 0, 0, 0, 0 } };

        }
    }

    class Block_L : Figure
    {
        public Block_L(byte R, byte G, byte B) : base(R, G, B)
        {
            Type = "L-Block";
            FigGeometry = new byte[4, 4] { { 1, 1, 1, 1 },
                                           { 1, 0, 0, 0 },
                                           { 0, 0, 0, 0 },
                                           { 0, 0, 0, 0 } };

        }
    }

    class Block_T : Figure
    {
        public Block_T(byte R, byte G, byte B) : base(R, G, B)
        {
            Type = "T-Block";
            FigGeometry = new byte[4, 4] { { 1, 1, 1, 0 },
                                           { 0, 1, 0, 0 },
                                           { 0, 0, 0, 0 },
                                           { 0, 0, 0, 0 } };

        }
    }
}
