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
            if (PasoActual > maxPasos)
                return;

            float t = PasoActual / (float)Math.Max(1, maxPasos);

            float escala = 20f + (float)Math.Sin(t * Math.PI * 2f) * 8f;
            float offset = (float)Math.Cos(t * Math.PI) * 100f;

            // --- FLECHA ---
            flecha.rebootAll(new PointF(center.X - offset, center.Y));
            flecha.scaleF = escala;
            flecha.roteGrade(t * 360f);
            flecha.createFigure();

            using (var penF = new Pen(Color.Red, 4))
            {
                g.DrawPolygon(penF, flecha.GetPoints());
            }

            // --- ESTRELLA --- CORREGIDO PARA VERSE
            estrella.rebootAll(new PointF(center.X + offset, center.Y));
            estrella.scaleF = 200;

            // ✅ FORZAMOS parámetros claramente visibles
            estrella.ReadData(5, 60f, 120f);
            estrella.roteGrade(-t * 360f);
            estrella.createFigure();

            // ✅ VERDE ↔ AMARILLO
            Color colorEstrella = (PasoActual % 2 == 0) ?
                Color.FromArgb(255, 100, 255, 100) : // verde claro
                Color.FromArgb(255, 255, 230, 80);   // amarillo cálido

            using (var penE = new Pen(colorEstrella, 4))
            {
                g.DrawPolygon(penE, estrella.GetPoints());
            }
        }


        public void Clear()
        {
            // No cleanup needed
        }
    }
}
