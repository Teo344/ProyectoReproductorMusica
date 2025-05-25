using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Figuras
{

    public abstract class Figure
    {

        public PointF position { get; set; }

        public float rotationGrade { get; set; } = 0;

        public float scaleF { get; set; } = 10;


        public Graphics mGraph;
        public Pen mPen;


        public Figure(PointF position)
        {
            this.position = position;
        }


        public void rebootPosition(PointF posicion) {
            position = posicion;
        }

        public void rebootRotation()
        {
            rotationGrade = 0;
        }

        public void rebootScale()
        {
            scaleF = 10;
        }

        public virtual void translate(float dx, float dy)
        {
            position = new PointF(position.X + dx, position.Y + dy);
        }

        public virtual void roteGrade(float grade)
        {
            rotationGrade += grade;
        }

        public virtual void scale(float factor)
        {
            scaleF += factor;

        }

        protected PointF RotatePoint(PointF point)
        {
            float angleRadians = (float)(Math.PI / 180) * rotationGrade;
            float cos = (float)Math.Cos(angleRadians);
            float sin = (float)Math.Sin(angleRadians);

            float dx = point.X - position.X;
            float dy = point.Y - position.Y;

            float xNew = position.X + dx * cos - dy * sin;
            float yNew = position.Y + dx * sin + dy * cos;

            return new PointF(xNew, yNew);
        }


        public virtual void drawFigure(Graphics g, Color color)
        {
            // Implementación de la figura
        }



    }

}
