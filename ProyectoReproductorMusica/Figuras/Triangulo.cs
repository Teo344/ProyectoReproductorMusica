using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Figuras
{
    class CTriangle: Figuras.Figure
    {
        private float mSideA;
        private float mSideB;
        private float mSideC;
        private List<PointF> mPoints = new List<PointF>();


        public CTriangle(PointF position) : base(position) {
            mSideA = 0.0f; mSideB = 0.0f; mSideC = 0.0f;
        }

        public void ReadData(float SideA, float SideB, float SideC)
        {
            mSideA = SideA;
            mSideB = SideB;
            mSideC = SideC;
        }


        public void createFigure()
        {
            mPoints.Clear();

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

            float centerX = (A.X + B.X + C.X) / 3;
            float centerY = (A.Y + B.Y + C.Y) / 3;


            float offsetX = position.X - centerX;
            float offsetY = position.Y - centerY;

            A = new PointF(A.X + offsetX, A.Y + offsetY);
            B = new PointF(B.X + offsetX, B.Y + offsetY);
            C = new PointF(C.X + offsetX, C.Y + offsetY);

            if (rotationGrade != 0){
                A = RotatePoint(A);
                B = RotatePoint(B);
                C = RotatePoint(C);
            }

            mPoints.Add(A);
            mPoints.Add(B);
            mPoints.Add(C);
        }

        public override void drawFigure(Graphics mGraph, Color color)
        {
            mPen = new Pen(color, 3);
            mGraph.DrawPolygon(mPen, mPoints.ToArray());
        }

        public void rebootAll(PointF posicion)
        {
            rebootPosition(posicion);
            rebootRotation();
            rebootScale();
            createFigure();
        }



    }




}
