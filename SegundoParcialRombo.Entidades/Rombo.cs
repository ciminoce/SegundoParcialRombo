
namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {
        public int DiagonalMayor { get; set; }
        public int DiagonalMenor { get; set; }
        public Contorno Contorno { get; set; }
        private double lado;
        public double Lado
        {
            get { return CalcularLado(); }
           
        }

        public Rombo()
        {
            
        }
        public Rombo(int dM,int dm, Contorno contorno)
        {
            DiagonalMayor = dM;
            DiagonalMenor = dm;
            Contorno=contorno;
            lado = CalcularLado();
        }
        public override string ToString()
        {
            return $"Rombo: DM={DiagonalMayor} dm={DiagonalMenor}";        }
        private double CalcularLado()
        {
            return Math.Sqrt(Math.Pow(DiagonalMayor/2,2)+Math.Pow(DiagonalMenor/2,2));
        }
        public double GetPerimetro() => 4 * Lado;
        public double GetArea() => DiagonalMayor * DiagonalMenor / 2;
    }
}
