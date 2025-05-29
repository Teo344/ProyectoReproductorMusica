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
            float baseMayor = 5f;
            float baseMenor = 3f;

            float screenH = g.VisibleClipBounds.Height;
            float maxScaleF = screenH / baseMayor;

            float ring = screenH * 0.25f;

            Color[] cols = {
                Color.FromArgb(180, 255, 100, 100),   // rojo suave
                Color.FromArgb(180, 100, 255, 100),   // verde suave
                Color.FromArgb(180, 100, 100, 255)    // azul suave
            };

            int trail = 6;
            for (int m = 0; m < 3; m++)
            {
                float ang = m * 120f * (float)Math.PI / 180f;
                PointF loc = new PointF(
                    center.X + (float)Math.Cos(ang) * ring,
                    center.Y + (float)Math.Sin(ang) * ring);

                for (int k = 0; k < trail; k++)
                {
                    float j = PasoActual - k * 3;
                    if (j < 0) continue;
                    float t = j / (float)Math.Max(1, maxPasos);

                    rhombus.rebootAll(loc);
                    rhombus.ReadData(baseMayor, baseMenor);

                    rhombus.scaleF = 1f + t * (maxScaleF - 1f);

                    float rot = t * 360f * (1 + m) + k * 20f;
                    rhombus.roteGrade(rot);
                    rhombus.createFigure();

                    int alpha = (int)(180 * (1 - k / (float)trail) * t);
                    Color col = Color.FromArgb(alpha, cols[m].R, cols[m].G, cols[m].B);
                    float penWidth = 4f - k * 0.5f;

                    using (Pen pen = new Pen(col, penWidth))
                    {
                        g.DrawPolygon(pen, rhombus.GetPoints());
                    }
                }
            }
        }

        public void Clear()
        {
            // No hay estado interno que limpiar
        }
}
}
