using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;
using System;
using System.Drawing;

namespace ProyectoReproductorMusica.Animaciones
{
    public class RhombusAnimacion : IAnimacion
    {
        private readonly CRombo rhombus;
        private readonly int maxPasos;

        public bool IsFinished { get; private set; }
        public int PasoActual { get; private set; }

        public RhombusAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            rhombus = new CRombo(new PointF(0, 0));
        }

        public void Start()
        {
            IsFinished = false;
            PasoActual = 0;
        }

        public void Update(int paso)
        {
            PasoActual = paso;
            if (PasoActual >= maxPasos)
                IsFinished = true;
        }

        public void Draw(Graphics g, PointF center)
        {
            // Parámetros del rombo base (diagonales antes de escalar)
            float baseMayor = 5f;
            float baseMenor = 3f;

            // Calcula escala máxima para cubrir pantalla
            float screenWidth = g.VisibleClipBounds.Width;
            float screenHeight = g.VisibleClipBounds.Height;
            // Usamos la diagonal mayor para cobertura vertical
            float maxScaleF = screenHeight / baseMayor;

            for (int j = 0; j <= PasoActual; j++)
            {
                float t = j / (float)Math.Max(1, maxPasos);

                rhombus.rebootAll(center);
                rhombus.ReadData(baseMayor, baseMenor);

                // Escala progresiva: de 1 hasta maxScaleF
                rhombus.scaleF = 1f + t * (maxScaleF - 1f);

                // Rotación suave
                rhombus.roteGrade(t * 360f * 2f); // 2 vueltas completas
                rhombus.createFigure();

                // Color pulsante: opacidad según t
                int alpha = (int)(200 * (1 - Math.Abs(2 * t - 1)));
                Color col = Color.FromArgb(alpha, 200, (int)(50 + 205 * t), 100);

                using (Pen pen = new Pen(col, 3))
                {
                    g.DrawPolygon(pen, rhombus.GetPoints());
                }
            }
        }

        public void Clear() { }
    }
}
