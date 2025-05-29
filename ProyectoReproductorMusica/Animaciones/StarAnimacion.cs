using System;
using System.Drawing;
using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;

namespace ProyectoReproductorMusica.Animaciones
{
    public class StarAnimacion : IAnimacion
    {
        private readonly CEstrella estrella;
        private readonly int maxPasos;
        private bool isFinished;

        public StarAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
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
            estrella.ReadData(5, 30f, 60f); 

            for (int j = 0; j <= PasoActual; j++)
            {
                float t = j / (float)Math.Max(1, maxPasos);

                estrella.rebootAll(center);

                float scaleOsc = 1.5f + (float)Math.Sin(t * Math.PI) * 1.0f;
                estrella.scaleF = scaleOsc;

                estrella.roteGrade(t * 360f);

                float offsetY = (float)Math.Cos(t * Math.PI * 2f) * 30f;

                float offsetX = (float)Math.Sin(t * Math.PI * 2f) * 80f; 

                estrella.translate(offsetX, offsetY);

                Color color = (j % 2 == 0) ? Color.FromArgb(255, 255, 255 - (int)(100 * t), 0) 
                                           : Color.FromArgb(255, 0, 100 + (int)(155 * t), 255); 

                estrella.createFigure();
                using (var pen = new Pen(color, 4))
                {
                    g.DrawPolygon(pen, estrella.GetPoints());
                }
            }
        }


        public void Clear()
        {
            // No requiere limpieza
        }
    }
}
