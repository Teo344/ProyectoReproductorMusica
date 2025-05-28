using ProyectoReproductorMusica.Animaciones;
using ProyectoReproductorMusica.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoReproductorMusica
{
    public partial class FrmReproductor : Form
    {
        private IAnimacion[] escenas;
        private int indiceEscena = 0;
        private int pasoActual = 0;
        private readonly int maxPasos = 300;
        private Timer animTimer = new Timer();

        public FrmReproductor()
        {
            InitializeComponent();
            animTimer.Interval = 50; // ~20 FPS
            animTimer.Tick += AnimTimer_Tick;

            escenas = new IAnimacion[]
            {
                new EllipseAnimacion(maxPasos),
                new TriangleAnimacion(200),
                new RhombusAnimacion(maxPasos),
                new StarAnimacion(maxPasos),
                new DesintegracionAnimacion(200),
            };
        }

        private void FrmReproductor_Load(object sender, EventArgs e)
        {
            NextScene();
            animTimer.Start();
        }

        private void NextScene()
        {
            pasoActual = 0;
            escenas[indiceEscena].Start();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
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

        private void picPause_Click(object sender, EventArgs e)
        {
            animTimer.Stop();
        }

        private void picPlay_Click(object sender, EventArgs e)
        {
            if (!escenas[indiceEscena].IsFinished)
                animTimer.Start();
        }

        private void picForward_Click(object sender, EventArgs e)
        {
            // Cambia a la siguiente escena y la inicia de inmediato
            animTimer.Stop();
            escenas[indiceEscena].Clear();
            indiceEscena = (indiceEscena + 1) % escenas.Length;
            NextScene();
            animTimer.Start();
            picCanvas.Invalidate();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            // Cambia a la escena anterior y la inicia de inmediato
            animTimer.Stop();
            escenas[indiceEscena].Clear();
            indiceEscena = (indiceEscena - 1 + escenas.Length) % escenas.Length;
            NextScene();
            animTimer.Start();
            picCanvas.Invalidate();
        }

        private void picFinish_Click(object sender, EventArgs e)
        {
            animTimer.Stop();
            escenas[indiceEscena].Clear();
            pasoActual = 0;
            picCanvas.Invalidate();
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var frm = new FrmHome())
                frm.ShowDialog();
            this.Close();
        }
    }
}
