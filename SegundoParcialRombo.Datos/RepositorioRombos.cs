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

    }
}
