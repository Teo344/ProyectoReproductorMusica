using System;
using System.Drawing;

namespace ProyectoReproductorMusica.Figuras
{
    public class CHexagono : Figure
    {
        private PointF[] puntos;

        public CHexagono(PointF position) : base(position) { }

        public void createFigure(float radio = 40f)
        {
            puntos = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                double angle = Math.PI / 3 * i;
                float x = position.X + (float)(radio * Math.Cos(angle)) * scaleF / 10f;
                float y = position.Y + (float)(radio * Math.Sin(angle)) * scaleF / 10f;
                puntos[i] = RotatePoint(new PointF(x, y));
            }
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
