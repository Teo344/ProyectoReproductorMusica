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
            if (PasoActual > maxPasos)
                return;

            float t = PasoActual / (float)Math.Max(1, maxPasos);

            float escala = 25f + (float)Math.Sin(t * Math.PI * 2f) * 5f;
            float offset = (float)Math.Cos(t * Math.PI) * 120f;

            // --- HEXÁGONO ---
            hexagono.rebootAll(new PointF(center.X - offset, center.Y));
            hexagono.scaleF = escala;
            hexagono.roteGrade(t * 180f);
            hexagono.createFigure();

            // Color dinámico tipo "luz" parpadeante azul
            Color colorH = Color.FromArgb(255, 0, (int)(100 + 155 * Math.Abs(Math.Sin(t * Math.PI * 2f))), 255);

            using (var penH = new Pen(colorH, 4))
            {
                penH.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                g.DrawPolygon(penH, hexagono.GetPoints());
            }

            // --- CRUZ ---
            cruz.rebootAll(new PointF(center.X + offset, center.Y));
            cruz.scaleF = escala;
            cruz.roteGrade(-t * 180f);
            cruz.createFigure();

            // Color dinámico tipo "luz" parpadeante naranja
            Color colorC = Color.FromArgb(255, 255, (int)(150 + 100 * Math.Abs(Math.Sin(t * Math.PI))), 0);

            using (var penC = new Pen(colorC, 4))
            {
                penC.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                g.DrawPolygon(penC, cruz.GetPoints());
            }
        }


        public void Clear()
        {
            // No requiere limpieza por ahora
        }
    }
}
