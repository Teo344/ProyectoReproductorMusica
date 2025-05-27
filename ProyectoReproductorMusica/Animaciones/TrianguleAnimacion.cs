using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;
using System;
using System.Drawing;

namespace ProyectoReproductorMusica.Animaciones
{
    public class TriangleAnimacion : IAnimacion
    {
        private readonly CTriangle[] triangles;
        private readonly Color[] colors = { Color.Red, Color.Green, Color.Blue };
        private readonly int maxPasos;
        private bool isFinished;

        public TriangleAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            // Prepara 3 instancias de triángulo, cambiarán posición y escala en Draw
            triangles = new CTriangle[3];
            for (int i = 0; i < 3; i++)
            {
                triangles[i] = new CTriangle(new PointF(0, 0));
                triangles[i].ReadData(5, 5, 5); // triángulo equilátero de lado 5
            }
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
                isFinished = true;
        }

        public void Draw(Graphics g, PointF center)
        {
            // Parámetro normalizado 0..1
            float t = PasoActual / (float)Math.Max(1, maxPasos);
            // Factor máximo de escala para cubrir pantalla
            float maxScale = Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) / (5f * 2f);

            for (int i = 0; i < triangles.Length; i++)
            {
                // Reinicia triángulo en el centro
                triangles[i].rebootAll(center);

                // Escala progresiva
                triangles[i].scaleF = 1f + t * maxScale;
                // Rotación a distinta velocidad por triángulo
                triangles[i].roteGrade(t * 360f * (i + 1));
                triangles[i].createFigure();

                // Color con alpha variable para suavizar aparición
                int alpha = (int)(200 * t);
                Color col = Color.FromArgb(alpha, colors[i]);

                using (var pen = new Pen(col, 3))
                {
                    g.DrawPolygon(pen, triangles[i].GetPoints());
                }
            }
        }

        public void Clear()
        {
            // Sin estado persistente aparte de PasoActual e isFinished
        }
    }
}
