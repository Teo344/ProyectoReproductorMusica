using System;
using System.Drawing;
using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;

namespace ProyectoReproductorMusica.Animaciones
{
    public class LatidoAnimacion : IAnimacion
    {
        private readonly CHexagono hexagono;
        private readonly CRombo rombo;
        private readonly int maxPasos;
        private bool isFinished;

        public LatidoAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            hexagono = new CHexagono(new PointF(0, 0));
            rombo = new CRombo(new PointF(0, 0));
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
            for (int j = 0; j <= PasoActual; j++)
            {
                float t = j / (float)Math.Max(1, maxPasos);
                float pulso = 1f + (float)Math.Sin(t * Math.PI * 2f) * 0.1f;
                float alpha = 120 + (int)(135 * Math.Abs(Math.Sin(t * Math.PI * 2f)));

                float sizeHex = 30f * pulso;
                float sizeRombo = 18f * pulso;

                hexagono.rebootAll(center);
                hexagono.scaleF = sizeHex;
                hexagono.rebootRotation();
                hexagono.createFigure();
                using (var penEye = new Pen(Color.FromArgb((int)alpha, 220, 220, 255), 3)) // Azul claro, blanco
                {
                    g.DrawPolygon(penEye, hexagono.GetPoints());
                }

                PointF left = new PointF(center.X - 35, center.Y);
                hexagono.rebootAll(left);
                hexagono.scaleF = sizeHex * 0.8f;
                hexagono.createFigure();
                using (var penLidL = new Pen(Color.FromArgb((int)alpha, 180, 180, 200), 2))
                {
                    g.DrawPolygon(penLidL, hexagono.GetPoints());
                }

                PointF right = new PointF(center.X + 35, center.Y);
                hexagono.rebootAll(right);
                hexagono.scaleF = sizeHex * 0.8f;
                hexagono.createFigure();
                using (var penLidR = new Pen(Color.FromArgb((int)alpha, 180, 180, 200), 2))
                {
                    g.DrawPolygon(penLidR, hexagono.GetPoints());
                }

                PointF top = new PointF(center.X, center.Y - 25);
                hexagono.rebootAll(top);
                hexagono.scaleF = sizeHex * 0.8f;
                hexagono.createFigure();
                using (var penTop = new Pen(Color.FromArgb((int)alpha, 180, 180, 200), 2))
                {
                    g.DrawPolygon(penTop, hexagono.GetPoints());
                }

                PointF bottom = new PointF(center.X, center.Y + 25);
                hexagono.rebootAll(bottom);
                hexagono.scaleF = sizeHex * 0.8f;
                hexagono.createFigure();
                using (var penBot = new Pen(Color.FromArgb((int)alpha, 180, 180, 200), 2))
                {
                    g.DrawPolygon(penBot, hexagono.GetPoints());
                }

                rombo.rebootAll(center);
                rombo.scaleF = sizeRombo;
                rombo.rebootRotation();
                rombo.roteGrade(45);
                rombo.createFigure();
                using (var penPupil = new Pen(Color.FromArgb((int)alpha, 30, 30, 60), 3))
                {
                    g.DrawPolygon(penPupil, rombo.GetPoints());
                }

                float eyeSize = 6f * pulso;
                using (var brush = new SolidBrush(Color.Black))
                {
                    g.FillEllipse(brush, center.X - eyeSize / 2, center.Y - eyeSize / 2, eyeSize, eyeSize);
                }
            }
        }


        public void Clear() { }
    }
}
