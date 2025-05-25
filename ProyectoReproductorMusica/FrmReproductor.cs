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
    public partial class FrmReproductor : Form
    {

        Timer delayTimer = new Timer();
        ProyectoReproductorMusica.Pantallas.PrimerPantalla pantalla = new ProyectoReproductorMusica.Pantallas.PrimerPantalla();
        bool mostrarFigura = false;
        int pasoActual = 0;
        int maxPasos = 10;
        Timer animTimer = new Timer();


        public FrmReproductor()
        {
            InitializeComponent();
            animTimer.Tick += AnimTimer_Tick;
            delayTimer.Tick += DelayTimer_Tick;
        }
        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop(); 
            pasoActual = 0;
            mostrarFigura = true; // <- ACTIVA EL DIBUJO
            animTimer.Interval = 500; // medio segundo por paso
            animTimer.Tick += AnimTimer_Tick;
            animTimer.Start();
        }


        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            pasoActual++;
            if (pasoActual > maxPasos)
            {
                animTimer.Stop();
                pantalla.Clear();
                pasoActual = 0;

            }
            picCanvas.Invalidate();
        }

        private void FrmReproductor_Load(object sender, EventArgs e)
        {
            delayTimer.Interval =2000; 
            delayTimer.Start();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            PointF center = new PointF(picCanvas.Width / 2f, picCanvas.Height / 2f);
            if (mostrarFigura)
            {
                pantalla.drawScreen(e.Graphics, center, pasoActual);
            }



        }

        private void picPause_Click(object sender, EventArgs e)
        {
            animTimer.Stop();
        }

        private void picPlay_Click(object sender, EventArgs e)
        {
            if (pasoActual < maxPasos)
            {
                animTimer.Start();
            }
        }

        private void picForward_Click(object sender, EventArgs e)
        {
            pasoActual += 5;
            if (pasoActual > maxPasos) pasoActual = maxPasos;
            picCanvas.Invalidate();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            pasoActual -= 5;
            if (pasoActual < 0) pasoActual = 0;
            picCanvas.Invalidate();
        }

        private void picFinish_Click(object sender, EventArgs e)
        {
            animTimer.Stop();
            pasoActual = 0;
            pantalla.Clear();
            picCanvas.Invalidate();
        }


        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmHome frm = new FrmHome())
            {
                frm.ShowDialog(); // Abres el nuevo formulario de forma modal
            }

            this.Close();
        }




    }



}
