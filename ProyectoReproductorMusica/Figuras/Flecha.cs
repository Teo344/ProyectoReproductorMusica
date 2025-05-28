using System;
using System.Drawing;

namespace ProyectoReproductorMusica.Figuras
{
    public class CFlecha : Figure
    {
        private PointF[] puntos;

        public CFlecha(PointF position) : base(position) { }

        public void createFigure()
        {
            float s = scaleF;

            PointF[] pts = new PointF[]
            {
                new PointF(position.X, position.Y - 40 * s / 10f),
                new PointF(position.X - 20 * s / 10f, position.Y - 10 * s / 10f),
                new PointF(position.X - 10 * s / 10f, position.Y - 10 * s / 10f),
                new PointF(position.X - 10 * s / 10f, position.Y + 40 * s / 10f),
                new PointF(position.X + 10 * s / 10f, position.Y + 40 * s / 10f),
                new PointF(position.X + 10 * s / 10f, position.Y - 10 * s / 10f),
                new PointF(position.X + 20 * s / 10f, position.Y - 10 * s / 10f)
            };

            puntos = new PointF[pts.Length];
            for (int i = 0; i < pts.Length; i++)
                puntos[i] = RotatePoint(pts[i]);
        }

        public PointF[] GetPoints() => puntos;

        public void rebootAll(PointF newCenter)
        {
            rebootPosition(newCenter);
            rebootRotation();
            rebootScale();
        }
    }
}
