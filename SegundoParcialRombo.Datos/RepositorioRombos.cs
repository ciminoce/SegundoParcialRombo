using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Datos
{
    public class RepositorioRombos
    {
        private List<Rombo>? rombos;
        private string nombreArchivo = "Rombos.txt";
        private string rutaProyecto = Environment.CurrentDirectory;
        private string? rutaCompletaArchivo;
        public RepositorioRombos()
        {
            rombos = new List<Rombo>();
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
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
        public List<Rombo>? GetRombos()
        {
            return rombos;
        }
        public void GuardarDatos()
        {
            using (var escritor = new StreamWriter(rutaCompletaArchivo!))
            {
                foreach (var rombo in rombos)
                {
                    string linea = ConstruirLinea(rombo);
                }
            }
        }

        private string ConstruirLinea(Rombo rombo)
        {
            return $"{rombo.DiagonalMayor}|{rombo.DiagonalMenor}|{rombo.Contorno.GetHashCode()}";
        }
    }
}
