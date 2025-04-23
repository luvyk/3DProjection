using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Test3D
{
    public class Plane
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }

        public Plane(decimal x, decimal y, decimal z, decimal d)
        {
            A = x;
            B = y;
            C = z;
            D = d;
        }

        public Plane()
        {
            A = 0;
            B = 0;
            C = 0;
            D = 0;
        }

        public Plane GetPlane(Vertex ver1, Vertex ver2, Vertex ver3)
        {
            Vector v1 = Vector.GetVectorFromVertexes(ver1, ver2);
            Vector v2 = Vector.GetVectorFromVertexes(ver1, ver3);

            //Vector nV1 = Vector.NormalizeVector(v1);
            //Vector nV2 = Vector.NormalizeVector(v2);

            Vector kolV = Vector.GetperpendicularVector(v1, v2);
            Vector norKolV = Vector.NormalizeVector(kolV);

            decimal Dnumber = -(norKolV.X * ver1.PoziceX + norKolV.Y * ver1.PoziceY + norKolV.Z * ver1.PoziceZ);

            return new Plane(norKolV.X, norKolV.Y, norKolV.Z, Dnumber);
        }


    }
}
