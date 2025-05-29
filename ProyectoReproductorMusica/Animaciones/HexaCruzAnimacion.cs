using System;
using System.Drawing;
using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;

namespace ProyectoReproductorMusica.Animaciones
{
    public class HexaCruzAnimacion : IAnimacion
    {
        private readonly CHexagono hexagono;
        private readonly CCruz cruz;
        private readonly int maxPasos;
        private bool isFinished;

        public HexaCruzAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            hexagono = new CHexagono(new PointF(0, 0));
            cruz = new CCruz(new PointF(0, 0));
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
            int trailCount = 5;

            // Estela de hexágonos psicodélicos
            for (int k = 0; k < trailCount; k++)
            {
                float tk = t - k * 0.04f;
                if (tk <= 0) continue;

                // Posición mezclada con rotación de estela
                float dx = (float)Math.Cos(tk * Math.PI * 2f) * 150f;
                float dy = (float)Math.Sin(tk * Math.PI * 3f) * 50f;
                hexagono.rebootAll(new PointF(center.X - dx, center.Y - dy));

                // Escala pulsante y creciente
                float baseScale = 25f + tk * 100f;
                float pulse = 1f + (float)Math.Sin(tk * Math.PI * 4f) * 0.2f;
                hexagono.scaleF = baseScale * pulse;

                // Rotación continua inversa cada línea
                hexagono.roteGrade((k % 2 == 0 ? 1 : -1) * tk * 360f * 1.5f);
                hexagono.createFigure();

                // Color con matiz azul-verde y alpha decreciente
                int alpha = (int)(200 * (1 - k / (float)trailCount));
                Color colH = Color.FromArgb(alpha,
                    (int)(0 + 200 * tk) % 256,
                    (int)(255 * Math.Abs(Math.Sin(tk * Math.PI * 2f))),
                    255);

                using (Pen pen = new Pen(colH, 5f - k))
                {
                    g.DrawPolygon(pen, hexagono.GetPoints());
                }
            }

            // Estela de cruces psicodélicas
            for (int k = 0; k < trailCount; k++)
            {
                float tk = t - k * 0.05f;
                if (tk <= 0) continue;

                float dx = (float)Math.Cos(tk * Math.PI * 3f) * 100f;
                float dy = (float)Math.Cos(tk * Math.PI * 2f) * 80f;
                cruz.rebootAll(new PointF(center.X + dx, center.Y + dy));

                float baseScale = 15f + tk * 120f;
                float wobble = 1f + (float)Math.Cos(tk * Math.PI * 3f) * 0.15f;
                cruz.scaleF = baseScale * wobble;

                cruz.roteGrade(tk * 360f * (k + 1));
                cruz.createFigure();

                int alphaC = (int)(180 * (1 - k / (float)trailCount));
                Color colC = Color.FromArgb(alphaC,
                    255,
                    (int)(150 * tk) + 50,
                    (int)(150 + 100 * (1 - tk)) % 256);

                using (Pen pen = new Pen(colC, 4f - k * 0.5f))
                {
                    g.DrawPolygon(pen, cruz.GetPoints());
                }
            }
        }

        public void Clear()
        {
            // No cleanup needed
        }
    }
}