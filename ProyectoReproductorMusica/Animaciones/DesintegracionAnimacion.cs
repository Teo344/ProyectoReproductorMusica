using System;
using System.Collections.Generic;
using System.Drawing;
using ProyectoReproductorMusica.Figuras;
using ProyectoReproductorMusica.Interfaces;

namespace ProyectoReproductorMusica.Animaciones
{
    public class DesintegracionAnimacion : IAnimacion
    {
        private readonly CEstrella figura;
        private readonly int maxPasos;
        private bool isFinished;
        private PointF[] puntosOriginales;

        // Nuevos campos para animar desplazamiento y escala
        private float desplazamientoMax = 100f; // Máximo desplazamiento horizontal
        private float escalaMin = 1.5f;
        private float escalaMax = 3.5f;

        public DesintegracionAnimacion(int maxPasos)
        {
            this.maxPasos = maxPasos;
            figura = new CEstrella(new PointF(0, 0));
        }

        public bool IsFinished => isFinished;
        public int PasoActual { get; private set; }

        public void Start()
        {
            isFinished = false;
            PasoActual = 0;
        }

        public void Update(int paso)
        {
            PasoActual = paso;
            if (PasoActual >= maxPasos)
                isFinished = true;
        }

        public void Draw(Graphics g, PointF center)
        {
            float t = PasoActual / (float)Math.Max(1, maxPasos);

            // Movimiento oscilante horizontal (de izquierda a derecha y viceversa)
            float desplazamientoX = desplazamientoMax * (float)Math.Sin(t * Math.PI * 2);
            PointF centroAnimado = new PointF(center.X + desplazamientoX, center.Y);

            // Escalado oscilante entre escalaMin y escalaMax
            float escala = escalaMin + (escalaMax - escalaMin) * 0.5f * (1 + (float)Math.Sin(t * Math.PI * 2));
            figura.scaleF = 0.8f;

            figura.rebootAll(centroAnimado);
            figura.createFigure();
            puntosOriginales = figura.GetPoints();

            // Rotación oscilante: de 0 a ±30 grados
            float rotacion = (float)(2 * Math.PI * t); // Rota 360° a lo largo de toda la animació

            // Color cíclico entre Tomate → Verde → Blanco
            Color colorTomate = Color.Tomato;
            Color colorVerde = Color.Green;
            Color colorBlanco = Color.White;
            Color colorActual;

            float ciclo = t * 3 % 1;

            if (t * 3 < 1)
                colorActual = InterpolarColor(colorTomate, colorVerde, ciclo);
            else if (t * 3 < 2)
                colorActual = InterpolarColor(colorVerde, colorBlanco, ciclo);
            else
                colorActual = InterpolarColor(colorBlanco, colorTomate, ciclo);

            // Aplicar transparencia
            int alpha = (int)(255 * (1 - t));
            alpha = Clamp(alpha, 0, 255);
            colorActual = Color.FromArgb(alpha, colorActual.R, colorActual.G, colorActual.B);

            // Calcular puntos desplazados y rotados
            PointF[] puntosDesplazados = new PointF[puntosOriginales.Length];
            for (int i = 0; i < puntosOriginales.Length; i++)
            {
                PointF p = puntosOriginales[i];

                float angle = i * (float)(2 * Math.PI / puntosOriginales.Length);
                float dx = (float)Math.Cos(angle) * 50f * t;
                float dy = (float)Math.Sin(angle) * 50f * t;

                float xRot = (p.X + dx - centroAnimado.X) * (float)Math.Cos(rotacion) - (p.Y + dy - centroAnimado.Y) * (float)Math.Sin(rotacion);
                float yRot = (p.X + dx - centroAnimado.X) * (float)Math.Sin(rotacion) + (p.Y + dy - centroAnimado.Y) * (float)Math.Cos(rotacion);

                puntosDesplazados[i] = new PointF(centroAnimado.X + xRot, centroAnimado.Y + yRot);
            }

            using (Pen pen = new Pen(colorActual, 2))
            using (Brush brush = new SolidBrush(colorActual))
            {
                g.FillPolygon(brush, puntosDesplazados);
                g.DrawPolygon(pen, puntosDesplazados);
            }
        }

        private int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private Color InterpolarColor(Color c1, Color c2, float t)
        {
            int r = (int)(c1.R + (c2.R - c1.R) * t);
            int g = (int)(c1.G + (c2.G - c1.G) * t);
            int b = (int)(c1.B + (c2.B - c1.B) * t);
            return Color.FromArgb(r, g, b);
        }

        public void Clear() { }
    }
}
