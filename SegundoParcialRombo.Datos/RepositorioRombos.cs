using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Datos
{
    public class RepositorioRombos
    {
        private List<Rombo>? rombos;
        public RepositorioRombos()
        {
            rombos = new List<Rombo>();
        }
        public int GetCantidad()
        {
            return rombos!.Count;
        }
        public bool Existe(Rombo rombo)
        {
            return rombos!.Any(r=>r.DiagonalMayor==rombo.DiagonalMayor && 
                    r.DiagonalMenor==rombo.DiagonalMenor && 
                    r.Contorno==rombo.Contorno);
        }
        public void Agregar(Rombo rombo)
        {
            rombos!.Add(rombo);
        }
        public List<Rombo> GetRombos()
        {
            return rombos;
        }
    }
}
