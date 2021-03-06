﻿using System.IO;

namespace DependencyInversion.Sensors
{
    public class Camera : ISensor, IMovable, IHeightAdjustable, IMeasurable
    {
        private float zoomLevel;
        private float x, y;

        public string GetName() => "camera";

        public void Move(float x, float y)
        {
            this.x += x;
            this.y += y;
        }

        public void Raise(float height)
        {
            zoomLevel += height;
        }

        public void Lower(float height)
        {
            zoomLevel -= height;
        }

        public void WriteMeasurement(TextWriter writer)
        {
            writer.WriteLine("This is a .NET core image");
        }
    }
}