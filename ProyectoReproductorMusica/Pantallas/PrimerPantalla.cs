using ProyectoReproductorMusica.Figuras;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoReproductorMusica.Pantallas
{
    class PrimerPantalla
    {
        private CTriangle objTriangle;
        private CEllipse objEllipse;

        public void drawScreen(Graphics g, PointF center, int paso)
        {
            // Dibujar triángulos en espiral azul
            objTriangle = new CTriangle(center);
            objTriangle.ReadData(5, 5, 5);
            objTriangle.rebootAll(center);

            float triAngleStep = 360f / Math.Max(1, paso);
            float triScale = 1f + paso * 0.05f;
            for (int i = 0; i < paso; i++)
            {
                objTriangle.rotationGrade = i * triAngleStep;
                objTriangle.scaleF = triScale;
                objTriangle.createFigure();
                using (var pen = new Pen(Color.FromArgb(200, Color.CornflowerBlue), 2))
                {
                    g.DrawPolygon(pen, objTriangle.GetPoints());
                }
            }

            // Psicodelia de elipses: estela que crece y se encoge
            objEllipse = new CEllipse(center);
            objEllipse.ReadData(9, 5);

            float maxScaleOsc = 50f; // factor máximo de escala
            for (int j = 0; j < paso; j++)
            {
                float t = j / (float)Math.Max(1, paso - 1); // 0..1

                // Oscilación de escala: sube hasta max y vuelve
                float scaleOsc = 1f + (float)Math.Sin(t * Math.PI) * maxScaleOsc;
                objEllipse.rebootAll(center);
                objEllipse.scaleF = scaleOsc;

                // Rotación continua
                objEllipse.roteGrade(t * 360f * 2); // dos vueltas completas

                // Translación vertical oscilante para dar dinamismo
                float offsetY = (float)Math.Cos(t * Math.PI * 2) * 50f;
                objEllipse.translate(0, offsetY);

                // Color variable: cambia matiz y opacidad según t
                int alpha = (int)(200 * (1 - t));
                Color col = Color.FromArgb(alpha,
                    (int)(100 + 155 * t),   // R crece con t
                    (int)(50 + 205 * (1 - t)), // G decrece
                    200);                   // B fijo

                objEllipse.createFigure();
                using (var pen = new Pen(col, 3))
                {
                    g.DrawPolygon(pen, objEllipse.GetPoints());
                }
            }
        }

        public void Clear()
        {
            // No hay estado persistente que limpiar.
        }
    }
}