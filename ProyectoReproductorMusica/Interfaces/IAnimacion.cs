using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoReproductorMusica.Interfaces
{
    public interface IAnimacion
    {
        void Start();
        void Update(int paso);
        void Draw(Graphics g, PointF center);
        bool IsFinished { get; }
        void Clear();
    }

}
