using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3D
{
    public class Vertex
    {
        public decimal PoziceX {  get; set; }
        public decimal PoziceY { get; set; }
        public decimal PoziceZ { get; set; }
        public List<Vertex>? PripojeneVertexy { get; set; }

        public Vertex(decimal poziceX, decimal poziceY, decimal poziceZ)
        {
            PoziceX = poziceX;
            PoziceY = poziceY;
            PoziceZ = poziceZ;
            PripojeneVertexy = null;
        }
    }
}
