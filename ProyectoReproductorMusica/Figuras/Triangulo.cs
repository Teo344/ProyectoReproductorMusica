using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Figuras
{
    class CTriangle : Figure
    {
        private float mSideA;
        private float mSideB;
        private float mSideC;
        private List<PointF> mPoints = new List<PointF>();

        public CTriangle(PointF position) : base(position)
        {
            mSideA = 0.0f;
            mSideB = 0.0f;
            mSideC = 0.0f;
        }

        public void ReadData(float sideA, float sideB, float sideC)
        {
            mSideA = sideA;
            mSideB = sideB;
            mSideC = sideC;
        }

        public void createFigure()
        {
            mPoints.Clear();

            // Lados base
            float a = mSideA;
            float b = mSideB;
            float c = mSideC;

            PointF A = new PointF(0, 0);
            PointF B = new PointF(c, 0);
            float x = (b * b + c * c - a * a) / (2 * c);
            float y = (float)Math.Sqrt(Math.Max(0, b * b - x * x));
            PointF C = new PointF(x, y);

            A = new PointF(A.X * scaleF, -A.Y * scaleF);
            B = new PointF(B.X * scaleF, -B.Y * scaleF);
            C = new PointF(C.X * scaleF, -C.Y * scaleF);

            float centerX = (A.X + B.X + C.X) / 3f;
            float centerY = (A.Y + B.Y + C.Y) / 3f;
            float offX = position.X - centerX;
            float offY = position.Y - centerY;
            A = new PointF(A.X + offX, A.Y + offY);
            B = new PointF(B.X + offX, B.Y + offY);
            C = new PointF(C.X + offX, C.Y + offY);

            if (rotationGrade != 0)
            {
                A = RotatePoint(A);
                B = RotatePoint(B);
                C = RotatePoint(C);
            }

            mPoints.Add(A);
            mPoints.Add(B);
            mPoints.Add(C);
        }
        public override void drawFigure(Graphics g, Color color)
        {
            if (mPoints == null || mPoints.Count == 0)
                createFigure();

            using (Pen pen = new Pen(color, 3))
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
