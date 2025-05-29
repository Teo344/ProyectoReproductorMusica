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
            float t = PasoActual / (float)Math.Max(1, maxPasos);
            // Factor máximo de escala para cubrir pantalla
            float maxScale = Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) / (5f * 2f);

            for (int i = 0; i < triangles.Length; i++)
            {
                // Efecto de estela con triángulos fantasma
                int trailCount = 8;
                float step = maxPasos / (float)trailCount;

                for (int k = 0; k < trailCount; k++)
                {
                    float ghostStep = PasoActual - k * step;
                    if (ghostStep < 0) continue;
                    float tg = ghostStep / (float)Math.Max(1, maxPasos);

                    // Reinicia triángulo en el centro
                    triangles[i].rebootAll(center);

                    // Pulso de escala y crecimiento
                    float pulse = 1f + (float)Math.Sin((tg * Math.PI * 4f) + i) * 0.2f;
                    triangles[i].scaleF = 1f + tg * maxScale * pulse;

                    // Rotación con variación por instancia
                    triangles[i].rotationGrade = tg * 360f * (i + 1);
                    triangles[i].createFigure();

                    // Color dinámico y alpha decreciente según cola
                    int alpha = (int)(200 * tg * (1 - k / (float)trailCount));
                    Color baseCol = colors[i];
                    Color col = Color.FromArgb(alpha,
                        (baseCol.R + (int)(120 * tg)) % 256,
                        (baseCol.G + (int)(120 * (1 - tg))) % 256,
                        (baseCol.B + (int)(200 * Math.Abs(0.5f - tg))) % 256);

                    using (Pen pen = new Pen(col, 4f - k * 0.3f))
                    {
                        g.DrawPolygon(pen, triangles[i].GetPoints());
                    }
                }
            }
        }


        public void Clear()
        {
            // Sin estado persistente aparte de PasoActual e isFinished
        }
    }
}
