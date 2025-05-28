using System;
using System.Drawing;

namespace ProyectoReproductorMusica.Figuras
{
    public class CCruz : Figure
    {
        private PointF[] puntos;

        public CCruz(PointF position) : base(position) { }

        public void createFigure()
        {
            float s = scaleF;
            PointF[] pts = new PointF[]
            {
                new PointF(position.X - 10 * s / 10f, position.Y - 30 * s / 10f),
                new PointF(position.X + 10 * s / 10f, position.Y - 30 * s / 10f),
                new PointF(position.X + 10 * s / 10f, position.Y - 10 * s / 10f),
                new PointF(position.X + 30 * s / 10f, position.Y - 10 * s / 10f),
                new PointF(position.X + 30 * s / 10f, position.Y + 10 * s / 10f),
                new PointF(position.X + 10 * s / 10f, position.Y + 10 * s / 10f),
                new PointF(position.X + 10 * s / 10f, position.Y + 30 * s / 10f),
                new PointF(position.X - 10 * s / 10f, position.Y + 30 * s / 10f),
                new PointF(position.X - 10 * s / 10f, position.Y + 10 * s / 10f),
                new PointF(position.X - 30 * s / 10f, position.Y + 10 * s / 10f),
                new PointF(position.X - 30 * s / 10f, position.Y - 10 * s / 10f),
                new PointF(position.X - 10 * s / 10f, position.Y - 10 * s / 10f)
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
