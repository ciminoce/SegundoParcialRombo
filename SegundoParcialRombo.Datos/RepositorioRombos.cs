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
            rombos = LeerDatos();
        }
        public int GetCantidad(Contorno? contorno=null)
        {
            if (contorno is null)
            {
                return rombos!.Count;
            }
            return rombos.Count(r => r.Contorno == contorno);
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
                    escritor.WriteLine(linea);
                }
            }
        }
        private List<Rombo> LeerDatos()
        {
            var lista = new List<Rombo>();
            if (!File.Exists(rutaCompletaArchivo))
            {
                return lista;
            }
            using (var lector=new StreamReader(rutaCompletaArchivo!))
            {
                while (!lector.EndOfStream)
                {
                    string? lineaLeida = lector.ReadLine();
                    Rombo rombo = ConstruirRombo(lineaLeida);
                    lista.Add(rombo);
                }
            }
            return lista;
        }

        private Rombo ConstruirRombo(string? lineaLeida)
        {
            var campos = lineaLeida!.Split("|");
            int DM = int.Parse(campos[0]);
            int dm = int.Parse(campos[1]);
            Contorno contorno =(Contorno) int.Parse(campos[2]);
            return new Rombo(DM, dm, contorno);
        }

        private string ConstruirLinea(Rombo rombo)
        {
            return $"{rombo.DiagonalMayor}|{rombo.DiagonalMenor}|{rombo.Contorno.GetHashCode()}";
        }

        public void Borrar(Rombo rombo)
        {
            rombos.Remove(rombo);
        }
        public List<Rombo> GetListaOrdenada(Orden orden)
        {
            if (orden==Orden.Asc)
            {
                return rombos.OrderBy(r => r.Lado).ToList();
            }
            return rombos.OrderByDescending(r => r.Lado).ToList();
        }

        public List<Rombo>? Filtrar(Contorno contorno)
        {
            return rombos!.Where(r => r.Contorno == contorno).ToList();
        }
    }
}
