using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRombos : Form
    {
        private RepositorioRombos repo;
        private List<Rombo>? lista;
        private int cantidad;
        public frmRombos()
        {
            InitializeComponent();
            repo = new RepositorioRombos();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRomboAE frm = new frmRomboAE() { Text = "Agregar Rombo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Rombo? rombo = frm.GetRombo();
            if (rombo is null)
            {
                return;
            }
            if (!repo.Existe(rombo))
            {
                repo.Agregar(rombo);
                cantidad = repo.GetCantidad();
                var r = ConstruirFila();
                SetearFila(r, rombo);
                AgregarFila(r);
                MostrarCantidad();
                MessageBox.Show($"Rombo {rombo.ToString()} agregado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show($"Rombo {rombo.ToString()} existente", "Mensaje", MessageBoxButtons.OK,
    MessageBoxIcon.Error);

            }
        }


        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var rSeleccionada = dgvDatos.SelectedRows[0];
            Rombo rombo = (Rombo)rSeleccionada.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el rombo {rombo.ToString()}?",
                "Confirmar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            repo.Borrar(rombo);
            QuitarFila(rSeleccionada);
            cantidad = repo.GetCantidad();
            MostrarCantidad();
            MessageBox.Show($"Rombo {rombo.ToString()} borrado", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
        }


        private void CargarComboContornos(ref ToolStripComboBox tsCboBordes)
        {
            var listaBordes = Enum.GetValues(typeof(Contorno));
            foreach (var item in listaBordes)
            {
                tsCboBordes.Items.Add(item);
            }
            tsCboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            tsCboBordes.SelectedIndex = 0;

        }


        private void lado09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.GetListaOrdenada(Orden.Asc);
            MostrarDatosEnGrilla();
        }

        private void lado90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.GetListaOrdenada(Orden.Desc);
            MostrarDatosEnGrilla();

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            lista = repo.GetRombos();
            cantidad = repo.GetCantidad();
            MostrarCantidad();
            MostrarDatosEnGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            repo.GuardarDatos();
            MessageBox.Show("Fin del programa", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            Application.Exit();
        }

        private void frmRombos_Load(object sender, EventArgs e)
        {
            CargarComboContornos(ref tsCboContornos);
            cantidad = repo.GetCantidad();
            if (cantidad > 0)
            {
                lista = repo.GetRombos();
                MostrarDatosEnGrilla();
            }
            MostrarCantidad();
        }

        private void MostrarCantidad()
        {
            txtCantidad.Text = cantidad.ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var rombo in lista!)
            {
                var r = ConstruirFila();
                SetearFila(r, rombo);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Rombo rombo)
        {
            r.Cells[colMayor.Index].Value = rombo.DiagonalMayor;
            r.Cells[colMenor.Index].Value = rombo.DiagonalMenor;
            r.Cells[colBorde.Index].Value = rombo.Contorno;
            r.Cells[colLado.Index].Value = rombo.Lado.ToString("N2");
            r.Cells[colPerimetro.Index].Value = rombo.GetPerimetro().ToString("N2");
            r.Cells[colArea.Index].Value = rombo.GetArea().ToString("N2");

            r.Tag = rombo;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsCboContornos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contorno contorno =(Contorno) tsCboContornos.SelectedItem!;
            lista = repo.Filtrar(contorno);
            cantidad = repo.GetCantidad(contorno);
            MostrarDatosEnGrilla();
            MostrarCantidad();
        }
    }
}
