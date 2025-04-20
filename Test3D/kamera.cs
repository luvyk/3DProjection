using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3D
{
    public class kamera
    {
        public Vertex ZakladniBod { get; set; }
        public Vertex DruhyBod { get; set; }
        public decimal DelkaDohledu { get; set; }
        public decimal UhelPohleduX { get; set; }
        public decimal UhelPohleduY { get; set; }
        public decimal NatoceniKamery { get; set; }
        public int SirkaSnimace { get; set; }
        public int VyskaSnimace { get; set; }


        public Vertex PomocnyBod { get; set; }
        public Vertex BodKameryA { get; set; }
        public Vertex BodKameryB { get; set; }
        public Vertex BodKameryC { get; set; }
        public Vertex BodKameryD { get; set; }

        public kamera(Vertex zakladniBod, Vertex druhyBod, decimal uhelPohleduX, decimal uhelPohleduY, decimal uhelPohledu, int sirkaSnimace, int vyskaSnimace)
        {
            ZakladniBod = zakladniBod;
            DruhyBod = druhyBod;
            UhelPohleduX = uhelPohleduX;
            UhelPohleduY = uhelPohleduY;
            SirkaSnimace = sirkaSnimace;
            VyskaSnimace = vyskaSnimace;
            DelkaDohledu = 1000;
            NatoceniKamery = 0;


            BodKameryA = GetPointInTriangle(true, true);
            BodKameryB = GetPointInTriangle(true, true);
            BodKameryC = GetPointInTriangle(true, true);
            BodKameryD = GetPointInTriangle(true, true);
            RotateCamera();
        }

        public List<Vertex> VyberVertexy()
        {

            return new List<Vertex>() { };
        }

        public Vertex GetMiddleOfBase()
        {
            Vector v = Vector.GetVectorFromVertexes(ZakladniBod, DruhyBod);
            v = Vector.NormalizeVector(v);
            Vertex Middle = v.MoveByVectorAndLenght(ZakladniBod, DelkaDohledu);
            return Middle;
        }

        public void RotateCamera()
        {
            //works only up to some 70 degrees... maybe
            PomocnyBod = ZakladniBod;
            PomocnyBod.PoziceX += 10;
            Vector kolmyVector = Vector.GetperpendicularVector(Vector.GetVectorFromVertexes(ZakladniBod, DruhyBod), Vector.GetVectorFromVertexes(ZakladniBod, PomocnyBod));
            Vector kolmyNormalVector = Vector.NormalizeVector(kolmyVector);
            //decimal delkaPreponyProOtoceniK = (decimal)Math.Sqrt(Math.Pow((double)PomocnyBod.PoziceX - (double)ZakladniBod.PoziceX, 2) + Math.Pow((double)PomocnyBod.PoziceY - (double)ZakladniBod.PoziceY, 2) + Math.Pow((double)PomocnyBod.PoziceZ - (double)ZakladniBod.PoziceZ, 2)) / (decimal)Math.Cos(30);
            decimal delkaPreponyProOtoceniK = 10 / (decimal)Math.Cos((double)NatoceniKamery);
            decimal delkaCestyNahoru = (decimal)Math.Sqrt(Math.Pow((double)delkaPreponyProOtoceniK, 2) - Math.Pow((double)100, 2));
            PomocnyBod = kolmyNormalVector.MoveByVectorAndLenght(PomocnyBod, delkaCestyNahoru);
        }

        public Vertex GetPointInTriangle(bool isXPositive, bool isYPositive)
        {
            Vertex MiddleOfTheBase = GetMiddleOfBase();

            decimal delkaPreponyX = DelkaDohledu / (decimal)Math.Cos((double)UhelPohleduX);
            decimal delkaPosunutiX = (decimal)Math.Sqrt(Math.Pow((double)delkaPreponyX,2) - Math.Pow((double)DelkaDohledu,2));
            decimal delkaPreponyY = DelkaDohledu / (decimal)Math.Cos((double)UhelPohleduY);
            decimal delkaPosunutiY = (decimal)Math.Sqrt(Math.Pow((double)delkaPreponyY, 2) - Math.Pow((double)DelkaDohledu, 2));



            Vector v = Vector.GetVectorFromVertexes(ZakladniBod, PomocnyBod);
            Vector vKol = Vector.GetperpendicularVector(Vector.GetVectorFromVertexes(ZakladniBod, DruhyBod), v);
            Vector nV = Vector.NormalizeVector(v);
            Vector nVKon = Vector.NormalizeVector(vKol);
            //Vertex pravaStrana = nV.MoveByVectorAndLenght(MiddleOfTheBase, delkaPosunutiX);

            switch ((isXPositive, isYPositive))
            {
                case (true, true):
                    Vertex vertexNaVraceni = MiddleOfTheBase;
                    vertexNaVraceni = nV.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiX);
                    vertexNaVraceni = nVKon.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiY);
                    return vertexNaVraceni;
                    break;
                case (true, false):
                    Console.WriteLine("První je true, druhá je false.");
                    break;
                case (false, true):
                    Console.WriteLine("První je false, druhá je true.");
                    break;
                case (false, false):
                    Console.WriteLine("Obě hodnoty jsou false.");
                    break;
            }


            return new Vertex(0, 0, 0);
        }
    }
}
