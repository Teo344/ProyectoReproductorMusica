using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProyectoReproductorMusica.Figuras
{
    public class CEstrella : Figure
    {
        private int numPuntas;
        private float radioInterno, radioExterno;
        private List<PointF> starPoints = new List<PointF>();

        public CEstrella(PointF position) : base(position)
        {
            numPuntas = 5;
            radioInterno = 10f;
            radioExterno = 20f;
        }

        public void ReadData(int puntas, float rInterno, float rExterno)
        {
            numPuntas = puntas;
            radioInterno = rInterno;
            radioExterno = rExterno;
        }

        public void createFigure()
        {
            starPoints.Clear();
            double angleStep = Math.PI / numPuntas;

            for (int i = 0; i < 2 * numPuntas; i++)
            {
                float r = (i % 2 == 0) ? radioExterno : radioInterno;
                double angle = i * angleStep;
                float x = position.X + (float)(r * Math.Cos(angle)) * scaleF;
                float y = position.Y + (float)(r * Math.Sin(angle)) * scaleF;

                PointF p = RotatePoint(new PointF(x, y));
                starPoints.Add(p);
            }
        }

        public override void drawFigure(Graphics g, Color color)
        {
            if (starPoints == null || starPoints.Count < 2)
                createFigure();

            using (Pen pen = new Pen(color, 2))
            {
                g.DrawPolygon(pen, starPoints.ToArray());
            }
        }

        public void rebootAll(PointF pos)
        {
            rebootPosition(pos);
            rebootRotation();
            rebootScale();
        }

        public PointF[] GetPoints()
        {
            if (starPoints.Count == 0)
                createFigure();
            return starPoints.ToArray();
        }
    }
}
