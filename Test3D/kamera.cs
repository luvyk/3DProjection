﻿using System;
using System.Collections.Generic;
using System.Drawing;
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

        public kamera(Vertex zakladniBod, Vertex druhyBod, decimal uhelPohleduX, decimal uhelPohleduY, int sirkaSnimace, int vyskaSnimace)
        {
            ZakladniBod = zakladniBod;
            DruhyBod = druhyBod;
            UhelPohleduX = uhelPohleduX;
            UhelPohleduY = uhelPohleduY;
            SirkaSnimace = sirkaSnimace;
            VyskaSnimace = vyskaSnimace;
            DelkaDohledu = 1000;
            NatoceniKamery = 0;
            PomocnyBod = new Vertex(0, 0, 0);

            RotateCamera();
            BodKameryA = GetPointInTriangle(true, true);
            BodKameryB = GetPointInTriangle(true, false);
            BodKameryC = GetPointInTriangle(false, false);
            BodKameryD = GetPointInTriangle(false, true);
            //Console.WriteLine("");
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
            PomocnyBod.PoziceX = ZakladniBod.PoziceX;
            PomocnyBod.PoziceY = ZakladniBod.PoziceY;
            PomocnyBod.PoziceZ = ZakladniBod.PoziceZ;
            PomocnyBod.PoziceX += 10;
            Vector vec1 = Vector.GetVectorFromVertexes(ZakladniBod, DruhyBod);
            Vector vec2 = Vector.GetVectorFromVertexes(ZakladniBod, PomocnyBod);
            Vector kolmyVector = Vector.GetperpendicularVector(vec1, vec2);
            Vector kolmyNormalVector = Vector.NormalizeVector(kolmyVector);
            //decimal delkaPreponyProOtoceniK = (decimal)Math.Sqrt(Math.Pow((double)PomocnyBod.PoziceX - (double)ZakladniBod.PoziceX, 2) + Math.Pow((double)PomocnyBod.PoziceY - (double)ZakladniBod.PoziceY, 2) + Math.Pow((double)PomocnyBod.PoziceZ - (double)ZakladniBod.PoziceZ, 2)) / (decimal)Math.Cos(30);
            decimal delkaPreponyProOtoceniK = 10 / (decimal)Math.Cos((double)NatoceniKamery);
            double delkaPreponyProOtoceniK2 = (double)Math.Round(delkaPreponyProOtoceniK, 15);
            double delkaCestyNahoru = Math.Sqrt(Math.Pow((double)delkaPreponyProOtoceniK2, 2) - Math.Pow(10, 2));
            PomocnyBod = kolmyNormalVector.MoveByVectorAndLenght(PomocnyBod, (decimal)delkaCestyNahoru);
        }

        public Vertex GetPointInTriangle(bool isXPositive, bool isYPositive)
        {
            Vertex MiddleOfTheBase = GetMiddleOfBase();

            decimal UhelPohleduXRad = UhelPohleduX * (decimal)Math.PI / 180;
            decimal UhelPohleduYRad = UhelPohleduY * (decimal)Math.PI / 180;
            decimal delkaPreponyX = DelkaDohledu / (decimal)Math.Cos((double)UhelPohleduXRad);
            decimal delkaPosunutiX = (decimal)Math.Sqrt(Math.Pow((double)delkaPreponyX,2) - Math.Pow((double)DelkaDohledu,2));
            decimal delkaPreponyY = DelkaDohledu / (decimal)Math.Cos((double)UhelPohleduYRad);
            decimal delkaPosunutiY = (decimal)Math.Sqrt(Math.Pow((double)delkaPreponyY, 2) - Math.Pow((double)DelkaDohledu, 2));



            Vector v1 = Vector.GetVectorFromVertexes(ZakladniBod, PomocnyBod);
            Vector v2 = Vector.GetVectorFromVertexes(ZakladniBod, DruhyBod);
            Vector vKol = Vector.GetperpendicularVector( v2, v1);
            Vector nV = Vector.NormalizeVector(v1);
            Vector nVKon = Vector.NormalizeVector(vKol);
            //Vertex pravaStrana = nV.MoveByVectorAndLenght(MiddleOfTheBase, delkaPosunutiX);

            //Vertex vertexNaVraceni = MiddleOfTheBase;
            Vertex vertexNaVraceni = new Vertex(0, 0, 0);
            vertexNaVraceni.PoziceX = MiddleOfTheBase.PoziceX;
            vertexNaVraceni.PoziceY = MiddleOfTheBase.PoziceY;
            vertexNaVraceni.PoziceZ = MiddleOfTheBase.PoziceZ;


            Vector minusNVKon = Vector.SwitchVector(nVKon);
            Vector minusNV = Vector.SwitchVector(nV);
            switch ((isXPositive, isYPositive))
            {
                case (true, true):
                    
                    vertexNaVraceni = nV.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiX);
                    vertexNaVraceni = nVKon.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiY);
                    return vertexNaVraceni;

                    break;
                case (true, false):
                    vertexNaVraceni = nV.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiX);
                    vertexNaVraceni = minusNVKon.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiY);
                    return vertexNaVraceni;

                    break;
                case (false, true):
                    vertexNaVraceni = minusNV.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiX);
                    vertexNaVraceni = nVKon.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiY);
                    return vertexNaVraceni;

                    break;
                case (false, false):
                    vertexNaVraceni = minusNV.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiX);
                    vertexNaVraceni = minusNVKon.MoveByVectorAndLenght(vertexNaVraceni, delkaPosunutiY);
                    return vertexNaVraceni;

                    break;
            }


            //return new Vertex(0, 0, 0);
        }
        
        public Bitmap ProjectPoints(List<Vertex> vertexes)
        {
            Plane baisicPlane = new Plane();
            baisicPlane = baisicPlane.GetPlane(BodKameryA, BodKameryB, BodKameryC);
            Bitmap Obrazek = new Bitmap(SirkaSnimace, VyskaSnimace);

            Plane plane1 = new Plane();
            plane1= plane1.GetPlane(ZakladniBod, BodKameryC, BodKameryD);
            Plane plane2 = new Plane();
            plane2 = plane2.GetPlane(ZakladniBod, BodKameryD, BodKameryA);

            foreach (Vertex vertex in vertexes)
            {
                    decimal distanceFromLeftPlane = vertex.GetDistanceFromPlane(plane1);
                    decimal distanceFromBottomLane = vertex.GetDistanceFromPlane(plane2);

                decimal distanceFromBack = vertex.GetDistanceFromPlane(baisicPlane);
                decimal distanceFromFront = DelkaDohledu - distanceFromBack;
                decimal UhelPohleduXRad = UhelPohleduX * (decimal)Math.PI / 180;
                decimal UhelPohleduYRad = UhelPohleduY * (decimal)Math.PI / 180;
                decimal delkaPreponyX = distanceFromFront / (decimal)Math.Cos((double)UhelPohleduXRad);
                decimal delkaPosunutiX = (decimal)Math.Sqrt(Math.Pow((double)delkaPreponyX, 2) - Math.Pow((double)distanceFromFront, 2));

                decimal delkaPreponyY = distanceFromFront / (decimal)Math.Cos((double)UhelPohleduYRad);
                decimal delkaPosunutiY = (decimal)Math.Sqrt(Math.Pow((double)delkaPreponyY, 2) - Math.Pow((double)distanceFromFront, 2));
                
                    decimal delkaTrojuhelnikuVBodeX = delkaPosunutiX * 2;
                    decimal delkaTrojuhelnikuVBodeY = delkaPosunutiY * 2;

                decimal relativePositionInCameraX = distanceFromLeftPlane / delkaTrojuhelnikuVBodeX;
                decimal relativePositionInCameraY = distanceFromBottomLane / delkaTrojuhelnikuVBodeY;

                decimal positionOnSensorX = relativePositionInCameraX * SirkaSnimace;
                decimal positionOnSensorY = relativePositionInCameraY * VyskaSnimace;

                using (Graphics g = Graphics.FromImage(Obrazek))
                {
                    g.FillRectangle(Brushes.Black, (int)Math.Round(positionOnSensorX, 0), (int)Math.Round(positionOnSensorY, 0), 4, 4);
                }
            }

            return Obrazek;
        }
    }
}
