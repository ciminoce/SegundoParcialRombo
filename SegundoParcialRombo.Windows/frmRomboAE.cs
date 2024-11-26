using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {
        private Rombo? rombo;
        public frmRomboAE()
        {
            InitializeComponent();
        }

        public Rombo? GetRombo()
        {
            return rombo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (rombo is null)
                {
                    rombo = new Rombo();
                }
                rombo.DiagonalMayor=int.Parse(txtDiagonalMayor.Text);
                rombo.DiagonalMenor = int.Parse(txtDiagonalMenor.Text);
                if (rbtSolido.Checked)
                {
                    rombo.Contorno = Contorno.Solido;
                }else if(rbtRayado.Checked){
                    rombo.Contorno=Contorno.Rayado;
                }else if (rbtDoble.Checked)
                {
                    rombo.Contorno = Contorno.Doble;
                }
                else
                {
                    rombo.Contorno = Contorno.Punteado;
                }
                DialogResult=DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtDiagonalMayor.Text,out int DM) || DM<=0)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMayor, "DM mal ingresada");
            }
            if (!int.TryParse(txtDiagonalMenor.Text, out int dm) || dm <= 0 || dm>=DM)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMenor, "dm mal ingresada");
            }
            return valido;
        }
    }
}
