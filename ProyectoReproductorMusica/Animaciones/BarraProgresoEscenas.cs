using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Animaciones
{
    public class BarraProgresoEscenas
    {
        private readonly PictureBox destino;
        private int totalEscenas;
        private int indiceEscena;
        private int pasoActual;
        private int maxPasos;

        public BarraProgresoEscenas(PictureBox pictureBoxDestino)
        {
            destino = pictureBoxDestino;
            destino.Paint += Dibujar;
        }

        public void Configurar(int totalEscenas, int maxPasos)
        {
            this.totalEscenas = totalEscenas;
            this.maxPasos = maxPasos;
        }

        public void Actualizar(int indiceEscena, int pasoActual)
        {
            this.indiceEscena = indiceEscena;
            this.pasoActual = pasoActual;
            destino.Invalidate();
        }

        private void Dibujar(object sender, PaintEventArgs e)
        {
            if (totalEscenas <= 0 || maxPasos <= 0)
                return;

            int anchoBloque = destino.Width / totalEscenas;
            int altoBloque = destino.Height;

            for (int i = 0; i < totalEscenas; i++)
            {
                Rectangle bloque = new Rectangle(i * anchoBloque, 0, anchoBloque, altoBloque);

                e.Graphics.FillRectangle(Brushes.Black, bloque);

                if (i < indiceEscena)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, bloque);
                }
                else if (i == indiceEscena)
                {
                    float porcentaje = Math.Min(1f, pasoActual / (float)maxPasos);
                    int anchoProgreso = (int)(anchoBloque * porcentaje);
                    Rectangle progreso = new Rectangle(i * anchoBloque, 0, anchoProgreso, altoBloque);
                    e.Graphics.FillRectangle(Brushes.Blue, progreso);
                }

            }
        }
    }

}
