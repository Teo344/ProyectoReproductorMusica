using ProyectoReproductorMusica.Animaciones;
using ProyectoReproductorMusica.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;
using AxWMPLib; // Para el control Windows Media Player


namespace ProyectoReproductorMusica
{
    public partial class FrmReproductor : Form
    {
        private IAnimacion[] escenas;
        private int indiceEscena = 0;
        private int pasoActual = 0;
        private readonly int maxPasos = 300;
        private Timer animTimer = new Timer();
        private BarraProgresoEscenas barraProgreso;

        public FrmReproductor()
        {
            InitializeComponent();
            animTimer.Interval = 50; // ~20 FPS
            animTimer.Tick += AnimTimer_Tick;

            wmpPlayer.URL = "C:\\Users\\MSI\\Desktop\\Imagenes\\Audios\\Las Avispas.mp3";
            escenas = new IAnimacion[]
            {
                new EllipseAnimacion(maxPasos),
                new TriangleAnimacion(maxPasos),
                new RhombusAnimacion(maxPasos),
                new StarAnimacion(maxPasos),
                new HexaCruzAnimacion(maxPasos),
                new ArrowStarAnimacion(maxPasos),
                new LatidoAnimacion(maxPasos),
                new CruzGiratoriaAnimacion(maxPasos)
            };
            barraProgreso = new BarraProgresoEscenas(picBarra);
            barraProgreso.Configurar(escenas.Length, maxPasos);

        }


        // Método para pausar música
        private void PausarMusica()
        {
            wmpPlayer.Ctlcontrols.pause();
        }

        // Método para detener música
        private void DetenerMusica()
        {
            wmpPlayer.Ctlcontrols.stop();
        }

        private void RetrocederMusica(int segundos = 5)
        {
            double nuevaPosicion = wmpPlayer.Ctlcontrols.currentPosition - segundos;
            if (nuevaPosicion < 0)
                nuevaPosicion = 0;  // No ir antes del inicio

            wmpPlayer.Ctlcontrols.currentPosition = nuevaPosicion;
        }

        private void AvanzarMusica(int segundos = 5)
        {
            double duracion = wmpPlayer.currentMedia?.duration ?? 0;
            double nuevaPosicion = wmpPlayer.Ctlcontrols.currentPosition + segundos;

            if (nuevaPosicion > duracion)
                nuevaPosicion = duracion;  // No ir más allá del final

            wmpPlayer.Ctlcontrols.currentPosition = nuevaPosicion;
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
            barraProgreso.Actualizar(indiceEscena, pasoActual);
            if (escena.IsFinished)
            {
                escena.Clear();

                if (indiceEscena == escenas.Length - 1)
                {
                    // Última escena finalizada: reiniciar a la primera
                    indiceEscena = 0;
                    // Reiniciar música a inicio
                    wmpPlayer.Ctlcontrols.currentPosition = 0;
                    wmpPlayer.Ctlcontrols.play();
                }
                else
                {
                    indiceEscena++;
                }

                NextScene();
            }

            picCanvas.Invalidate();
            picBarra.Invalidate();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            var center = new PointF(picCanvas.Width / 2f, picCanvas.Height / 2f);
            escenas[indiceEscena].Draw(e.Graphics, center);
        }

        private void picPause_Click(object sender, EventArgs e)
        {
            PausarMusica();
            animTimer.Stop();
        }

        private void picPlay_Click(object sender, EventArgs e)
        {
            if (!escenas[indiceEscena].IsFinished)
            {
                animTimer.Start();
                wmpPlayer.Ctlcontrols.play();  // Reanuda la música desde donde quedó
            }
        }

        private void picForward_Click(object sender, EventArgs e)
        {
            if (indiceEscena < escenas.Length - 1)
            {
                animTimer.Stop();
                escenas[indiceEscena].Clear();
                AvanzarMusica(5);
                indiceEscena++;
                pasoActual = 0;
                barraProgreso.Actualizar(indiceEscena, pasoActual);
                NextScene();

                animTimer.Start();
                picCanvas.Invalidate();
                picBarra.Invalidate();
            }

        }

        private void picBack_Click(object sender, EventArgs e)
        {
            if (indiceEscena > 0)
            {
                animTimer.Stop();
                escenas[indiceEscena].Clear();
                RetrocederMusica(5);
                indiceEscena--;
                pasoActual = 0;
                barraProgreso.Actualizar(indiceEscena, pasoActual);
                NextScene();

                animTimer.Start();
                picCanvas.Invalidate();
                picBarra.Invalidate();
            }

        }

        private void picFinish_Click(object sender, EventArgs e)
        {
            animTimer.Stop();
            escenas[indiceEscena].Clear();
            pasoActual = 0;
            indiceEscena = 0;

            DetenerMusica();
            wmpPlayer.Ctlcontrols.currentPosition = 0;
            wmpPlayer.Ctlcontrols.play();

            NextScene();

            animTimer.Start();
            picCanvas.Invalidate();
            picBarra.Invalidate();

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
