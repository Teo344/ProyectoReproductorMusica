using ProyectoReproductorMusica.Figuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace ProyectoReproductorMusica.Pantallas
{

    class PrimerPantalla
    {
        CTriangle ObjTriangle;
        CEllipse ObjEllipse;
        CRombo ObjRombo;

        private List<Figure> figures;

        public PrimerPantalla()
        {
            figures = new List<Figure>();
        }


        public void drawScreen(Graphics mGraph, PointF center, int pasosMax){

            //Creo todas la figuras iniciales
            ObjTriangle = new CTriangle(center);
            ObjTriangle.ReadData(5, 5, 5);
            ObjTriangle.rebootAll(center);



            for (int i = 0; i < pasosMax; i++)
            {
                ObjTriangle.drawFigure(mGraph, Color.Blue);
                ObjTriangle.scale(5);
                ObjTriangle.createFigure();

            }

            ObjTriangle.rebootAll(center);  

            ObjTriangle.translate(100, 0);
            ObjTriangle.roteGrade(90);
            ObjTriangle.createFigure();

            for (int i = 0; i < pasosMax; i++)
            {
                ObjTriangle.drawFigure(mGraph, Color.Red);
                ObjTriangle.scale(5);
                ObjTriangle.createFigure();
            }

            ObjTriangle.rebootAll(center);

            ObjTriangle.translate(-100, 0);
            ObjTriangle.roteGrade(-90);
            ObjTriangle.createFigure();
            ObjTriangle.drawFigure(mGraph, Color.Green);

            for (int i = 0; i < pasosMax; i++)
            {
                ObjTriangle.scale(5);
                ObjTriangle.createFigure();
                ObjTriangle.drawFigure(mGraph, Color.Green);
            }


            ObjTriangle.rebootAll(center);

            for (int i = 0; i < pasosMax; i++)
            {
                ObjTriangle.roteGrade(5);
                ObjTriangle.translate(50, 0);
                ObjTriangle.createFigure();
                ObjTriangle.drawFigure(mGraph, Color.Yellow);
            }

            ObjEllipse = new CEllipse(center);
            ObjEllipse.ReadData(9, 5);
            ObjEllipse.translate(100, 0);

            for (int i = 0; i < pasosMax; i++)
            {
                ObjEllipse.drawFigure(mGraph, Color.Purple);
                ObjEllipse.roteGrade(60);
                ObjEllipse.translate(0,20);
            }

            ObjEllipse.rebootAll(center);
            ObjEllipse.translate(-100, 0);
            ObjEllipse.roteGrade(-10);
            ObjEllipse.drawFigure(mGraph, Color.Purple);

            ObjRombo = new CRombo(center);
            ObjRombo.ReadData(9, 5);
            ObjRombo.translate(0, 100);
            ObjRombo.roteGrade(60);
            ObjRombo.createFigure();
            ObjRombo.drawFigure(mGraph, Color.Orange);

            ObjRombo.rebootAll(center);
            ObjRombo.ReadData(5, 5);
            ObjRombo.translate(0, -59);
            ObjRombo.createFigure();
            ObjRombo.drawFigure(mGraph, Color.Orange);

            ObjEllipse.ReadData(7, 5);
            ObjEllipse.rebootAll(center);
            ObjEllipse.translate(0, -60);
            ObjEllipse.drawFigure(mGraph, Color.Orange);

            ObjEllipse.rebootAll(center);
            ObjEllipse.translate(0, 60);
            ObjEllipse.drawFigure(mGraph, Color.Orange);

            ObjEllipse.rebootAll(center);
            ObjEllipse.translate(60, 0);
            ObjEllipse.roteGrade(90);
            ObjEllipse.drawFigure(mGraph, Color.Orange);

            ObjEllipse.rebootAll(center);
            ObjEllipse.translate(-60, 0);
            ObjEllipse.roteGrade(90);
            ObjEllipse.drawFigure(mGraph, Color.Orange);
        }

        public void Clear()
        {
            figures.Clear();
            ObjTriangle = null;
        }


    }





}
