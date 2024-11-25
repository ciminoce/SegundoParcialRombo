
namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {
        public int DiagonalMayor { get; set; }
        public int DiagonalMenor { get; set; }
        public double Lado { get; set; }
        public Rombo(int dM,int dm)
        {
            DiagonalMayor = dM;
            DiagonalMenor = dm;
            Lado = CalcularLado();
        }

        private double CalcularLado()
        {
            return Math.Sqrt(Math.Pow(DiagonalMayor/2,2)+Math.Pow(DiagonalMenor/2,2));
        }
        public double GetPerimetro() => 4 * Lado;
        public double GetArea() => DiagonalMayor * DiagonalMenor / 2;
    }
}
