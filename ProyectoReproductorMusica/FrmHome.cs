using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoReproductorMusica
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void picCanva2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmReproductor frm = new FrmReproductor())
            {
                frm.ShowDialog(); // Abres el nuevo formulario de forma modal
            }

            this.Close();
        }

        private void picPlay1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmReproductor frm = new FrmReproductor())
            {
                frm.ShowDialog(); // Abres el nuevo formulario de forma modal
            }

            this.Close();
        }
    }
}
