using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;
using System;
using System.Drawing;

namespace ProyectoReproductorMusica
{
    using ProyectoReproductorMusica.Animaciones;
    using ProyectoReproductorMusica.Interfaces;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FrmReproductor : Form
    {
        private IAnimacion[] escenas;
        private int indiceEscena = 0;
        private int pasoActual = 0;
        private readonly int maxPasos = 300;       // 600 pasos

        private Timer animTimer = new Timer();

        public FrmReproductor()
        {
            InitializeComponent();
            // Configurar timer de animación
            animTimer.Interval = 50; // ~20 FPS
            animTimer.Tick += AnimTimer_Tick;

            // Inicializar escenas
            escenas = new IAnimacion[]
            {
            new EllipseAnimacion(maxPasos),
            new TriangleAnimacion(200),
            new RhombusAnimacion(maxPasos)
            };

        }

        private void FrmReproductor_Load(object sender, System.EventArgs e)
        {
            NextScene();
            animTimer.Start();
        }

        private void NextScene()
        {
            pasoActual = 0;
            escenas[indiceEscena].Start();
        }

        private void AnimTimer_Tick(object sender, System.EventArgs e)
        {
            pasoActual++;
            var escena = escenas[indiceEscena];
            escena.Update(pasoActual);

            if (escena.IsFinished)
            {
                escena.Clear();
                indiceEscena = (indiceEscena + 1) % escenas.Length;
                NextScene();
            }

            picCanvas.Invalidate();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            var center = new PointF(picCanvas.Width / 2f, picCanvas.Height / 2f);
            escenas[indiceEscena].Draw(e.Graphics, center);
        }

        private void picPause_Click(object sender, System.EventArgs e)
        {
            animTimer.Stop();
        }

        private void picPlay_Click(object sender, System.EventArgs e)
        {
            if (!escenas[indiceEscena].IsFinished)
                animTimer.Start();
        }

        private void picFinish_Click(object sender, System.EventArgs e)
        {
            animTimer.Stop();
            escenas[indiceEscena].Clear();
            pasoActual = 0;
            picCanvas.Invalidate();
        }

        private void picHome_Click(object sender, System.EventArgs e)
        {
            // Volver a FrmHome
            this.Hide();
            using (var frm = new FrmHome())
                frm.ShowDialog();
            this.Close();
        }
    }
}
