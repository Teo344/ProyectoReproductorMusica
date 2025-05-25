using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Figuras
{
    class CRombo: Figuras.Figure
    {
        private float mDMayor;
        private float mDMenor;
        private List<PointF> mPoints = new List<PointF>();

        public CRombo(PointF position) : base(position)
        {
            mDMayor = 0.0f; mDMenor = 0.0f;
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

            PointF A = new PointF(position.X, position.Y -DMayor / 2);
            PointF B = new PointF(position.X + DMenor / 2, position.Y);
            PointF C = new PointF(position.X, position.Y+ DMayor / 2);
            PointF D = new PointF(position.X-DMenor / 2, position.Y);
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
