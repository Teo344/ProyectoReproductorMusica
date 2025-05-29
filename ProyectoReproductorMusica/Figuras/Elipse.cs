﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Figuras
{
    class CEllipse : Figure
    {
        private float mMayor;
        private float mMenor;
        private List<PointF> ellipsePoints = new List<PointF>();

        public CEllipse(PointF position) : base(position)
        {
            mMayor = 0.0f;
            mMenor = 0.0f;
        }

        public void ReadData(float mayor, float menor)
        {
            mMayor = mayor;
            mMenor = menor;
        }


        public void createFigure()
        {
            ellipsePoints.Clear();
            int numSteps = 360;      
            float angleStep = 360f / numSteps;

            float a = mMenor * scaleF;
            float b = mMayor * scaleF;

            for (int i = 0; i <= numSteps; i++)
            {
                float theta = i * angleStep * (float)Math.PI / 180f;
                float x = a * (float)Math.Cos(theta);
                float y = b * (float)Math.Sin(theta);

                PointF rotated = RotatePoint(new PointF(position.X + x, position.Y + y));
                ellipsePoints.Add(rotated);
            }
        }

        /// <summary>
        /// Dibuja la elipse en el Graphics dado usando los puntos generados por createFigure().
        /// </summary>
        public override void drawFigure(Graphics mGraph, Color color)
        {
            if (ellipsePoints == null || ellipsePoints.Count < 2)
                createFigure();

            using (Pen pen = new Pen(color, 2))
            {
                mGraph.DrawPolygon(pen, ellipsePoints.ToArray());
            }
        }


        public void rebootAll(PointF posicion)
        {
            rebootPosition(posicion);
            rebootRotation();
            rebootScale();
        }


        public PointF[] GetPoints()
        {
            if (ellipsePoints == null || ellipsePoints.Count == 0)
                createFigure();
            return ellipsePoints.ToArray();
        }
    }
}
