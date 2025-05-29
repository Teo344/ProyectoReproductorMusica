using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Figuras
{
    public class CRombo : Figure
    {
        private float mDMayor;
        private float mDMenor;
        private List<PointF> mPoints = new List<PointF>();

        public CRombo(PointF position) : base(position)
        {
            mDMayor = 0.0f;
            mDMenor = 0.0f;
        }

        public void ReadData(float mayor, float menor)
        {
            mDMayor = mayor;
            mDMenor = menor;
        }

        public void createFigure()
        {
            mPoints.Clear();
            float DMayor = mDMayor * scaleF;
            float DMenor = mDMenor * scaleF;

            PointF A = new PointF(position.X, position.Y - DMayor / 2);
            PointF B = new PointF(position.X + DMenor / 2, position.Y);
            PointF C = new PointF(position.X, position.Y + DMayor / 2);
            PointF D = new PointF(position.X - DMenor / 2, position.Y);

            if (rotationGrade != 0)
            {
                A = RotatePoint(A);
                B = RotatePoint(B);
                C = RotatePoint(C);
                D = RotatePoint(D);
            }

            mPoints.Add(A);
            mPoints.Add(B);
            mPoints.Add(C);
            mPoints.Add(D);
        }

        public override void drawFigure(Graphics g, Color color)
        {
            if (mPoints == null || mPoints.Count == 0)
                createFigure();

            using (var pen = new Pen(color, 3))
            {
                g.DrawPolygon(pen, mPoints.ToArray());
            }
        }
        public void rebootAll(PointF posicion)
        {
            rebootPosition(posicion);
            rebootRotation();
            rebootScale();
            createFigure();
        }

        public PointF[] GetPoints()
        {
            if (mPoints == null || mPoints.Count == 0)
                createFigure();
            return mPoints.ToArray();
        }
    }
}