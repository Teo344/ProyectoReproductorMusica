using System;
using System.Drawing;
using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;

namespace ProyectoReproductorMusica.Animaciones
{
    public class CruzGiratoriaAnimacion : IAnimacion
    {
        private readonly CCruz cruz;
        private readonly CEllipse elipse;
        private readonly int maxPasos;
        private bool isFinished;

        public CruzGiratoriaAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            cruz = new CCruz(new PointF(0, 0));
            elipse = new CEllipse(new PointF(0, 0));
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

                float alpha = 100 + 155 * Math.Abs((float)Math.Sin(t * Math.PI * 2));
                float elipseScale = 150f + 20f * (float)Math.Sin(t * Math.PI * 2);
                float cruzScale = 100f + 15f * (float)Math.Sin(t * Math.PI * 4);
                float rot = t * 720f;

                elipse.rebootAll(center);
                elipse.scaleF = elipseScale;
                elipse.rebootRotation();
                elipse.createFigure();

                using (var brushElipse = new SolidBrush(Color.FromArgb((int)alpha, 30, 144, 255)))
                {
                    g.FillPolygon(brushElipse, elipse.GetPoints());
                }
                using (var penElipse = new Pen(Color.FromArgb((int)alpha, 0, 191, 255), 4))
                {
                    g.DrawPolygon(penElipse, elipse.GetPoints());
                }

                cruz.rebootAll(center);
                cruz.scaleF = cruzScale;
                cruz.roteGrade(rot);
                cruz.createFigure();

                // Color dinámico arcoíris
                int r = (int)((Math.Sin(t * 2 * Math.PI) * 127) + 128);
                int gCol = (int)((Math.Sin(t * 2 * Math.PI + 2) * 127) + 128);
                int b = (int)((Math.Sin(t * 2 * Math.PI + 4) * 127) + 128);
                Color dynamicColor = Color.FromArgb((int)alpha, r, gCol, b);

                using (var penCruz = new Pen(dynamicColor, 6))
                {
                    g.DrawPolygon(penCruz, cruz.GetPoints());
                }
            }
        }

        public void Clear() { }
    }
}
