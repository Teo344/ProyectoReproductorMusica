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

                float alpha = 100 + 155 * (float)Math.Abs(Math.Sin(t * Math.PI * 2));
                float elipseScale = 150f + 20f * (float)Math.Sin(t * Math.PI * 2);
                float cruzScale = 100f + 15f * (float)Math.Sin(t * Math.PI * 4);
                float rot = t * 720f;

                // === ELIPSE: Azul intermitente ===
                elipse.rebootAll(center);
                elipse.scaleF = elipseScale;
                elipse.rebootRotation();
                elipse.createFigure();

                using (var brushElipse = new SolidBrush(Color.FromArgb((int)alpha, 30, 144, 255)))//Azul
                {
                    g.FillPolygon(brushElipse, elipse.GetPoints());
                }

                using (var penElipse = new Pen(Color.FromArgb((int)alpha, 0, 191, 255), 4)) 
                {
                    g.DrawPolygon(penElipse, elipse.GetPoints());
                }

                // === CRUZ: Blanca intermitente ===
                cruz.rebootAll(center);
                cruz.scaleF = cruzScale;
                cruz.roteGrade(rot);
                cruz.createFigure();

                using (var penCruz = new Pen(Color.FromArgb((int)alpha, 255, 255, 255), 6))//Blanco
                {
                    g.DrawPolygon(penCruz, cruz.GetPoints());
                }
            }
        }

        public void Clear() { }
    }
}
