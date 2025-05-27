using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;

namespace ProyectoReproductorMusica.Animaciones
{
    public class EllipseAnimacion : IAnimacion
    {
        private readonly CEllipse ellipse;
        private readonly int maxPasos;
        private bool isFinished;

        public EllipseAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            ellipse = new CEllipse(new PointF(0, 0));
        }

        public bool IsFinished => isFinished;

        public int PasoActual { get; private set; }

        public void Start()
        {
            isFinished = false;
            PasoActual = 0;
        }

        public void Update(int paso)
        {
            PasoActual = paso;
            if (PasoActual >= maxPasos)
            {
                isFinished = true;
            }
        }

        public void Draw(Graphics g, PointF center)
        {
            // Parámetros base
            ellipse.ReadData(9, 5);

            // Dibujo de estela psicodélica
            for (int j = 0; j <= PasoActual; j++)
            {
                float t = j / (float)Math.Max(1, maxPasos);

                // Reiniciar posición/rotación/escala
                ellipse.rebootAll(center);

                // Oscilación de escala
                float maxScaleOsc = 50f;
                float scaleOsc = 1f + (float)Math.Sin(t * Math.PI) * maxScaleOsc;
                ellipse.scaleF = scaleOsc;

                // Rotación continua (2 vueltas)
                ellipse.roteGrade(t * 360f * 2f);

                // Translación vertical oscilante
                float offsetY = (float)Math.Cos(t * Math.PI * 2f) * 50f;
                ellipse.translate(0, offsetY);

                // Color psicodélico con alpha variable
                int alpha = (int)(200 * (1 - t));
                Color col = Color.FromArgb(alpha,
                    (int)(100 + 155 * t),     // R aumenta
                    (int)(50 + 205 * (1 - t)), // G disminuye
                    200);                      // B fijo

                // Generar y dibujar puntos
                ellipse.createFigure();
                using (var pen = new Pen(col, 3))
                {
                    g.DrawPolygon(pen, ellipse.GetPoints());
                }
            }
        }

        public void Clear()
        {
            // No hay estado persistente aparte de PasoActual e isFinished
        }
    }
}
