using System;
using System.Drawing;
using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;

namespace ProyectoReproductorMusica.Animaciones
{
    public class ArrowStarAnimacion : IAnimacion
    {
        private readonly CFlecha flecha;
        private readonly CEstrella estrella;
        private readonly int maxPasos;
        private bool isFinished;

        public ArrowStarAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            flecha = new CFlecha(new PointF(0, 0));
            estrella = new CEstrella(new PointF(0, 0));
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
            int trailCount = 6;
            float ringRadius = Math.Min(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) * 0.3f;

            // Dibujar 3 sets de flecha + estrella en anillo
            for (int m = 0; m < 3; m++)
            {
                // Centro desplazado circularmente
                float angleOff = m * 120f * (float)Math.PI / 180f;
                PointF localCenter = new PointF(
                    center.X + (float)Math.Cos(angleOff) * ringRadius,
                    center.Y + (float)Math.Sin(angleOff) * ringRadius);

                // Flecha con estela psicodélica
                for (int k = 0; k < trailCount; k++)
                {
                    float tk = t - k * 0.02f;
                    if (tk <= 0) continue;

                    float offsetX = (float)Math.Cos(tk * Math.PI * 2f) * 80f;
                    float offsetY = (float)Math.Sin(tk * Math.PI * 4f) * 30f;
                    flecha.rebootAll(new PointF(localCenter.X - offsetX, localCenter.Y + offsetY));

                    float baseScale = 15f + t * 60f;
                    flecha.scaleF = baseScale * (1f + (float)Math.Sin(tk * Math.PI * 3f) * 0.1f);

                    float rot = tk * 360f * 2f * ((k % 2 == 0) ? 1 : -1) + m * 30f;
                    flecha.roteGrade(rot);
                    flecha.createFigure();

                    int alpha = (int)(200 * (1 - k / (float)trailCount));
                    Color col = Color.FromArgb(alpha,
                        (int)((1 - tk) * 255),
                        (int)(tk * 200),
                        (int)(100 + 155 * tk));

                    using (Pen pen = new Pen(col, 4 - k * 0.4f))
                        g.DrawPolygon(pen, flecha.GetPoints());
                }

                // Estrella con estela psicodélica
                for (int k = 0; k < trailCount; k++)
                {
                    float tk = t - k * 0.03f;
                    if (tk <= 0) continue;

                    float offset = (float)Math.Cos(tk * Math.PI * 2f) * 60f;
                    estrella.rebootAll(new PointF(localCenter.X + offset, localCenter.Y - offset));

                    float baseScaleE = 40f + tk * 150f;
                    estrella.scaleF = baseScaleE * (1f + (float)Math.Cos(tk * Math.PI * 2f) * 0.15f);

                    estrella.ReadData(5, 60f, 120f);
                    estrella.roteGrade(tk * 360f * 1.5f + m * -20f);
                    estrella.createFigure();

                    int alphaE = (int)(180 * (1 - k / (float)trailCount));
                    Color baseC = (k % 2 == 0) ? Color.Cyan : Color.Magenta;
                    Color colE = Color.FromArgb(alphaE,
                        (baseC.R + (int)(tk * 100)) % 256,
                        (baseC.G + (int)((1 - tk) * 100)) % 256,
                        (baseC.B + 50) % 256);

                    using (Pen pen = new Pen(colE, 3 - k * 0.3f))
                        g.DrawPolygon(pen, estrella.GetPoints());
                }
            }
        }

        public void Clear() { }
    }
}